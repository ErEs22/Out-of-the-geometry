using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
/// <summary>
/// 玩家的输入控制脚本
/// </summary>
[CreateAssetMenu(menuName = "PlayerInput")]
public class PlayerInput : ScriptableObject,
PlayerInputActions.ICameraControlActions,
PlayerInputActions.ICharacterControlActions,
PlayerInputActions.ILevelChoseActions,
PlayerInputActions.IPauseUIActions
{
    public event UnityAction<Vector2> onCamMove = delegate { };
    public event UnityAction<Vector2> onMove = delegate { };
    public event UnityAction onStopMove = delegate { };
    public event UnityAction onFire = delegate { };
    public event UnityAction onStopFire = delegate { };
    public event UnityAction onClickBlock = delegate { };
    public event UnityAction onPause = delegate { };
    public event UnityAction onResume = delegate { };
    PlayerInputActions playerInputActions;//新输入系统生成的脚本，提供动作表的接口
    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.CameraControl.SetCallbacks(this);
        playerInputActions.CharacterControl.SetCallbacks(this);
        playerInputActions.LevelChose.SetCallbacks(this);
        playerInputActions.PauseUI.SetCallbacks(this);
        playerInputActions.CharacterControl.Enable();
    }
    public void SwitchActionMap(InputActionMap actionMap)//切换动作表
    {
        playerInputActions.Disable();
        actionMap.Enable();
    }
    public void EnableAllActionMap()//将所有动作表设置为可用
    {
        playerInputActions.Enable();
    }
    public void SwitchToDynamicUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
    public void SwitchToFixedUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
    public void EnableCharacterControlMap() => SwitchActionMap(playerInputActions.CharacterControl);
    public void EnableLevelChoseMap() => SwitchActionMap(playerInputActions.LevelChose);
    public void EnablePauseUIMap() => SwitchActionMap(playerInputActions.PauseUI);
    public void DisableAllInputs() => playerInputActions.Disable();
    public void OnLook(InputAction.CallbackContext context)//缩放摄像机的远近，绑定按键为鼠标滚轮
    {
        if (context.performed)
        {
            onCamMove.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnMove(InputAction.CallbackContext context)//控制角色的移动，绑定按键为WASD
    {
        if (context.performed)
        {
            onMove.Invoke(context.ReadValue<Vector2>());
        }
        if (context.canceled)
        {
            onStopMove.Invoke();
        }
    }

    public void OnFire(InputAction.CallbackContext context)//控制角色的开火，绑定按键为鼠标左键
    {
        if (context.performed)
        {
            onFire.Invoke();
        }
        if (context.canceled)
        {
            onStopFire.Invoke();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onClickBlock.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onPause.Invoke();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onResume.Invoke();
        }
    }
}
