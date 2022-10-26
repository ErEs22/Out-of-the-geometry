using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class BGMController : Singleton<BGMController>
{
    AudioSource audioSource;
    float defaultVolume;
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        defaultVolume = audioSource.volume;
    }
    private void Start()
    {
        audioSource.volume = GameSetting.Instance.backgroundVolume * defaultVolume;
    }
    public void UpdateVolume()
    {
        audioSource.volume = GameSetting.Instance.backgroundVolume * defaultVolume;
    }
}
