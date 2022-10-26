using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class GameUIController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Canvas pauseCanvas;
    private void OnEnable()
    {
        playerInput.onPause += OnPause;
        playerInput.onResume += OnResume;
    }
    private void OnDisable()
    {
        playerInput.onPause -= OnPause;
        playerInput.onResume -= OnResume;
    }
    public void OnPause()
    {
        playerInput.SwitchToDynamicUpdateMode();
        Time.timeScale = 0f;
        pauseCanvas.enabled = true;
        // GameObject.FindGameObjectWithTag("PauseUI").GetComponent<Canvas>().enabled = true;
        playerInput.DisableAllInputs();
        playerInput.EnablePauseUIMap();
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        // GameObject.FindGameObjectWithTag("PauseUI").GetComponent<Canvas>().enabled = false;
        playerInput.SwitchToFixedUpdateMode();
        playerInput.DisableAllInputs();
        playerInput.EnableCharacterControlMap();
    }
}
