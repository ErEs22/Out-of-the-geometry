using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] Scrollbar SFXScrollBar;
    [SerializeField] Scrollbar backgroundScrollBar;
    [SerializeField] Toggle frameToggle;
    [SerializeField] Texture2D cursorNormal;
    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.SetCursor(cursorNormal, new Vector2(128, 128), CursorMode.Auto);
    }
    public void StartGameClick()
    {
        SceneController.Instance.LoadChoseLevelScene();
    }
    public void SaveSetting()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXScrollBar.value);
        PlayerPrefs.SetFloat("backgroundVolume", backgroundScrollBar.value);
        PlayerPrefs.SetInt("frame", frameToggle.isOn == true ? 1 : 0);
        GameSetting.Instance.SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
        GameSetting.Instance.backgroundVolume = PlayerPrefs.GetFloat("backgroundVolume", 0);
        GameSetting.Instance.frame = PlayerPrefs.GetInt("frame") == 1 ? true : false;
        BGMController.Instance.UpdateVolume();
    }
    public void SaveUI()
    {
        SFXScrollBar.value = PlayerPrefs.GetFloat("SFXVolume", 0);
        backgroundScrollBar.value = PlayerPrefs.GetFloat("backgroundVolume", 0);
        frameToggle.isOn = PlayerPrefs.GetInt("frame") == 1 ? true : false;
        // SFXScrollBar.value = GameSetting.Instance.SFXVolume;
        // backgroundScrollBar.value = GameSetting.Instance.backgroundVolume;
        // frameToggle.isOn = GameSetting.Instance.frame;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
