using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class LevelCubeEvent : MonoBehaviour
{
    [SerializeField] GameObject[] levelCubes;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Text[] scoreText;
    Coroutine moveUpCoroutine;
    Coroutine moveDownCoroutine;
    private void OnEnable()
    {
        playerInput.DisableAllInputs();
        playerInput.EnableLevelChoseMap();
        LoadLevelScore();
        MouseManager.Instance.OnMouseOver += MouseOver;
        MouseManager.Instance.OnMouseExit += MouseExit;
        playerInput.onClickBlock += OnclickBlock;
    }
    private void OnDisable()
    {
        MouseManager.Instance.OnMouseOver -= MouseOver;
        MouseManager.Instance.OnMouseExit -= MouseExit;
        playerInput.onClickBlock -= OnclickBlock;
    }
    void LoadLevelScore()
    {
        scoreText[0].text = PlayerPrefs.GetInt("Level05", 0).ToString();
        scoreText[1].text = PlayerPrefs.GetInt("Level04", 0).ToString();
        scoreText[2].text = PlayerPrefs.GetInt("Level03", 0).ToString();
        scoreText[3].text = PlayerPrefs.GetInt("Level02", 0).ToString();
        scoreText[4].text = PlayerPrefs.GetInt("Level01", 0).ToString();
    }
    void OnclickBlock()
    {
        if (MouseManager.Instance.hitInfo.collider == null)
        {
            return;
        }
        switch (MouseManager.Instance.hitInfo.collider.gameObject.name)
        {
            case "Level01":
                SceneController.Instance.LoadLevel01Scene();
                playerInput.DisableAllInputs();
                break;
            case "Level02":
                SceneController.Instance.LoadLevel02Scene();
                playerInput.DisableAllInputs();
                break;
            case "Level03":
                SceneController.Instance.LoadLevel03Scene();
                playerInput.DisableAllInputs();
                break;
            case "Level04":
                SceneController.Instance.LoadLevel04Scene();
                playerInput.DisableAllInputs();
                break;
            case "Level05":
                SceneController.Instance.LoadLevel05Scene();
                playerInput.DisableAllInputs();
                break;
            default: break;
        }
    }
    void MouseOver(GameObject hit)
    {
        if (moveDownCoroutine != null)
        {
            StopCoroutine(moveDownCoroutine);
        }
        moveUpCoroutine = StartCoroutine(MoveUp(hit));
        // animatorController.SetBool("Over", true);
    }
    void MouseExit()
    {
        if (moveUpCoroutine != null)
        {
            StopCoroutine(moveUpCoroutine);
        }
        moveDownCoroutine = StartCoroutine(MoveDown());
        // animatorController.SetBool("Over", false);
    }
    IEnumerator MoveUp(GameObject hit)
    {
        while (true)
        {
            hit.transform.position = Vector3.MoveTowards(hit.transform.position, new Vector3(hit.transform.position.x, 0.3f, hit.transform.position.z), 0.02f);
            foreach (var item in levelCubes)
            {
                if (item == hit)
                {
                    continue;
                }
                item.transform.position = Vector3.MoveTowards(item.transform.position, new Vector3(item.transform.position.x, 0, item.transform.position.z), 0.02f);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator MoveDown()
    {
        while (true)
        {
            foreach (var item in levelCubes)
            {
                item.transform.position = Vector3.MoveTowards(item.transform.position, new Vector3(item.transform.position.x, 0, item.transform.position.z), 0.02f);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
