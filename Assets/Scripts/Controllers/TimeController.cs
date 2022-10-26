using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 时间控制器
/// </summary>
public class TimeController : Singleton<TimeController>
{
    // [SerializeField] LevelController levelController;
    [SerializeField] Text timeText;//时间显示文本
    [SerializeField] Text frameText;//帧率显示文本
    [SerializeField] bool isShowFPS;//是否显示帧率
    [SerializeField] bool isShowCountDown;//是否显示倒计时
    public float seconds;
    WaitForSeconds waitForTime;

    float waitForTimeFlow = 1f;
    protected override void Awake()
    {
        base.Awake();
        waitForTime = new WaitForSeconds(waitForTimeFlow);
    }
    private void OnEnable()
    {
        isShowFPS = GameSetting.Instance.frame;
        if (isShowCountDown)
        {
            timeText.text = Mathf.Floor(seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
            StartCoroutine(nameof(TickingClockCoroutine));
        }
        if (isShowFPS)
        {
            frameText.gameObject.SetActive(true);
            StartCoroutine(nameof(UpdateFrameCoroutine));
        }
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(TickingClockCoroutine));
        StopCoroutine(nameof(UpdateFrameCoroutine));
    }
    IEnumerator TickingClockCoroutine()//倒计时携程
    {
        while (true)
        {
            yield return waitForTime;
            if (seconds == 0)
            {
                timeText.text = "00:00";
                GameManager.Instance.StartGameOverCoroutine();
                yield break;
            }
            else
            {
                seconds--;
                timeText.text = Mathf.Floor(seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
            }
        }
    }
    IEnumerator UpdateFrameCoroutine()//帧率显示携程
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float frame = 1 / Time.deltaTime;
            frameText.text = frame.ToString("00");
        }
    }
}
