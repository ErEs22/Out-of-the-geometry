using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
[System.Serializable]
public class AudioData
{
    public AudioClip audioClip;
    [Range(0f, 1f)] public float volume;
}
