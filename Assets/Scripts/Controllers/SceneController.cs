using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 
/// </summary>
public class SceneController : Singleton<SceneController>
{
    [SerializeField] Image blockImage;
    [SerializeField] float fadeTime;
    Color color;
    IEnumerator LoadCoroutine(string sceneName)
    {
        var loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingOperation.allowSceneActivation = false;
        blockImage.gameObject.SetActive(true);
        while (color.a < 1f)
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            blockImage.color = color;
            yield return null;
        }
        yield return new WaitUntil(() => loadingOperation.progress >= 0.9f);
        loadingOperation.allowSceneActivation = true;
        while (color.a > 0f)
        {
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            blockImage.color = color;
            yield return null;
        }
        blockImage.gameObject.SetActive(false);
    }
    public void LoadStartMenuScene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("StartMenu"));
    }
    public void LoadChoseLevelScene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("ChoseLevel"));
    }
    public void LoadLevel01Scene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("Level01"));
    }
    public void LoadLevel02Scene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("Level02"));
    }
    public void LoadLevel03Scene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("Level03"));
    }
    public void LoadLevel04Scene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("Level04"));
    }
    public void LoadLevel05Scene()
    {
        StopAllCoroutines();
        StartCoroutine(LoadCoroutine("Level05"));
    }
}
