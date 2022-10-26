using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 游戏管理器
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [SerializeField] Texture2D cursorAim;
    [SerializeField] float gameoverWaitTime;//游戏结束等待时间
    [SerializeField] AudioData gameoverSFX;
    public int currentLevel;//当前关卡
    [SerializeField] GameObject player;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Canvas gameoverCanvas;
    [HideInInspector] public bool gameover;
    WaitForSeconds waitForDisPlayUITime;
    protected override void Awake()
    {
        base.Awake();
        waitForDisPlayUITime = new WaitForSeconds(gameoverWaitTime);
    }
    private void Start()
    {
        Cursor.SetCursor(cursorAim, new Vector2(16, 16), CursorMode.Auto);
    }
    private void OnEnable()
    {
        playerInput.DisableAllInputs();
        playerInput.EnableCharacterControlMap();
    }
    private void OnDisable()
    {
    }
    public void BackToStartMenu()
    {
        SceneController.Instance.LoadStartMenuScene();
        playerInput.SwitchToFixedUpdateMode();
        playerInput.DisableAllInputs();
    }
    void StopGenerateCoroutine()
    {
        switch (currentLevel)
        {
            case 1:
                FindObjectOfType<Level01Controller>().StopGenerateEnemyCoroutine();
                break;
            case 2:
                FindObjectOfType<Level02Controller>().StopGenerateEnemyCoroutine();
                break;
            case 3:
                FindObjectOfType<Level03Controller>().StopGenerateEnemyCoroutine();
                break;
            case 4:
                FindObjectOfType<Level04Controller>().StopGenerateEnemyCoroutine();
                break;
            case 5:
                FindObjectOfType<Level05Controller>().StopGenerateEnemyCoroutine();
                break;
            default: break;
        }
    }
    public void StartGameOverCoroutine()
    {
        StartCoroutine(nameof(GameOverCoroutine));
    }
    public IEnumerator GameOverCoroutine()
    {
        AudioManager.Instance.PlaySFX(gameoverSFX);
        gameover = true;
        StopGenerateCoroutine();
        yield return new WaitForSeconds(1f);
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Enemy>()?.Explode();
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Boss"))
        {
            enemy.GetComponent<Enemy>()?.Explode();
        }
        if (player.activeSelf)
        {
            player.GetComponent<PlayerController>().Die();
        }
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) < ScoreManager.Instance.Score)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, ScoreManager.Instance.Score);
        }
        PlayerPrefs.Save();
        playerInput.DisableAllInputs();
        gameoverCanvas.enabled = true;
    }
}
