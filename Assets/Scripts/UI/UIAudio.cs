using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class UIAudio : Singleton<UIAudio>
{
    [SerializeField] AudioData buttonSelectedSFX;
    [SerializeField] AudioData buttonPressedSFX;
    public void Seleceted()
    {
        AudioManager.Instance.PlaySFX(buttonSelectedSFX);
    }
    public void Pressed()
    {
        AudioManager.Instance.PlaySFX(buttonPressedSFX);
    }
}
