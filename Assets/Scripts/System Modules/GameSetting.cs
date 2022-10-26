using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class GameSetting : PersistentSingleton<GameSetting>
{
    [HideInInspector] public float SFXVolume;
    [HideInInspector] public float backgroundVolume;
    [HideInInspector] public bool frame;
    protected override void Awake()
    {
        base.Awake();
        LoadSetting();
    }
    public void LoadSetting()
    {
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
        backgroundVolume = PlayerPrefs.GetFloat("backgroundVolume", 0);
        frame = PlayerPrefs.GetInt("frame") == 1 ? true : false;
    }
}
