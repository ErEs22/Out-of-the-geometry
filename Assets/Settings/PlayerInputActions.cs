//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""CameraControl"",
            ""id"": ""def3d30e-1f27-4d98-930b-228d78b771db"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""1c0a8d52-3902-4e31-8ad9-81ffe7aa0af9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""adbb82a9-a8b2-46d2-99b2-705884bd4403"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharacterControl"",
            ""id"": ""ec24f5cf-ab8c-48d8-9807-3a67f39aedb4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7fd9fd06-bbb6-4309-865a-596c261ece60"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""0e4f3162-5359-48cf-96ab-6f2fadf8e10f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9ce38acb-8d99-4701-a99e-6861ab02e849"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c373fdff-60d9-4475-8dc6-5ead1fb83acb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bcb45f05-2eff-4006-bdb6-46b01b732096"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a54ccbb-c696-453e-a0bf-c23d28afd403"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bb51b9ec-d6de-4dfe-979e-ea15624b449c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b5b8e67-bd5e-41bd-b93d-0e9b008a0393"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""40459961-96c6-4753-acc9-6622acec0bfa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54e6b540-66c2-4e10-b1ba-6d2cf01c2b65"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LevelChose"",
            ""id"": ""bd651e78-974d-44a3-a763-796383d180ad"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""fcd62f1e-5561-47a9-98be-b8589068ee40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b0caf321-6c0c-4ea6-83cb-92fcb76e8d0b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseUI"",
            ""id"": ""bd8e9b8d-4fbe-4209-98c6-20bde91dcb71"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""12c4f962-663b-4f27-8471-62fb98e1b133"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac417554-2f0e-4b6c-9c9a-4d27052262df"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CameraControl
        m_CameraControl = asset.FindActionMap("CameraControl", throwIfNotFound: true);
        m_CameraControl_Look = m_CameraControl.FindAction("Look", throwIfNotFound: true);
        // CharacterControl
        m_CharacterControl = asset.FindActionMap("CharacterControl", throwIfNotFound: true);
        m_CharacterControl_Move = m_CharacterControl.FindAction("Move", throwIfNotFound: true);
        m_CharacterControl_Fire = m_CharacterControl.FindAction("Fire", throwIfNotFound: true);
        m_CharacterControl_Pause = m_CharacterControl.FindAction("Pause", throwIfNotFound: true);
        // LevelChose
        m_LevelChose = asset.FindActionMap("LevelChose", throwIfNotFound: true);
        m_LevelChose_Click = m_LevelChose.FindAction("Click", throwIfNotFound: true);
        // PauseUI
        m_PauseUI = asset.FindActionMap("PauseUI", throwIfNotFound: true);
        m_PauseUI_Resume = m_PauseUI.FindAction("Resume", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CameraControl
    private readonly InputActionMap m_CameraControl;
    private ICameraControlActions m_CameraControlActionsCallbackInterface;
    private readonly InputAction m_CameraControl_Look;
    public struct CameraControlActions
    {
        private @PlayerInputActions m_Wrapper;
        public CameraControlActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_CameraControl_Look;
        public InputActionMap Get() { return m_Wrapper.m_CameraControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControlActions instance)
        {
            if (m_Wrapper.m_CameraControlActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_CameraControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public CameraControlActions @CameraControl => new CameraControlActions(this);

    // CharacterControl
    private readonly InputActionMap m_CharacterControl;
    private ICharacterControlActions m_CharacterControlActionsCallbackInterface;
    private readonly InputAction m_CharacterControl_Move;
    private readonly InputAction m_CharacterControl_Fire;
    private readonly InputAction m_CharacterControl_Pause;
    public struct CharacterControlActions
    {
        private @PlayerInputActions m_Wrapper;
        public CharacterControlActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControl_Move;
        public InputAction @Fire => m_Wrapper.m_CharacterControl_Fire;
        public InputAction @Pause => m_Wrapper.m_CharacterControl_Pause;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlActions instance)
        {
            if (m_Wrapper.m_CharacterControlActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnFire;
                @Pause.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_CharacterControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public CharacterControlActions @CharacterControl => new CharacterControlActions(this);

    // LevelChose
    private readonly InputActionMap m_LevelChose;
    private ILevelChoseActions m_LevelChoseActionsCallbackInterface;
    private readonly InputAction m_LevelChose_Click;
    public struct LevelChoseActions
    {
        private @PlayerInputActions m_Wrapper;
        public LevelChoseActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_LevelChose_Click;
        public InputActionMap Get() { return m_Wrapper.m_LevelChose; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelChoseActions set) { return set.Get(); }
        public void SetCallbacks(ILevelChoseActions instance)
        {
            if (m_Wrapper.m_LevelChoseActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_LevelChoseActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_LevelChoseActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_LevelChoseActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_LevelChoseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public LevelChoseActions @LevelChose => new LevelChoseActions(this);

    // PauseUI
    private readonly InputActionMap m_PauseUI;
    private IPauseUIActions m_PauseUIActionsCallbackInterface;
    private readonly InputAction m_PauseUI_Resume;
    public struct PauseUIActions
    {
        private @PlayerInputActions m_Wrapper;
        public PauseUIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Resume => m_Wrapper.m_PauseUI_Resume;
        public InputActionMap Get() { return m_Wrapper.m_PauseUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseUIActions set) { return set.Get(); }
        public void SetCallbacks(IPauseUIActions instance)
        {
            if (m_Wrapper.m_PauseUIActionsCallbackInterface != null)
            {
                @Resume.started -= m_Wrapper.m_PauseUIActionsCallbackInterface.OnResume;
                @Resume.performed -= m_Wrapper.m_PauseUIActionsCallbackInterface.OnResume;
                @Resume.canceled -= m_Wrapper.m_PauseUIActionsCallbackInterface.OnResume;
            }
            m_Wrapper.m_PauseUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Resume.started += instance.OnResume;
                @Resume.performed += instance.OnResume;
                @Resume.canceled += instance.OnResume;
            }
        }
    }
    public PauseUIActions @PauseUI => new PauseUIActions(this);
    public interface ICameraControlActions
    {
        void OnLook(InputAction.CallbackContext context);
    }
    public interface ICharacterControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ILevelChoseActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IPauseUIActions
    {
        void OnResume(InputAction.CallbackContext context);
    }
}
