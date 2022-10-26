using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class AudioManager : PersistentSingleton<AudioManager>
{
    AudioSource audioSource;
    float defaultVolume;
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        defaultVolume = audioSource.volume;
    }
    public void PlaySFX(AudioData audioData)
    {
        audioSource.PlayOneShot(audioData.audioClip, audioData.volume * GameSetting.Instance.SFXVolume);
    }
}
