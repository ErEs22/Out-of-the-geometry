using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 玩家分数管理类
/// </summary>
public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] Text scoreText;//分数显示文本
    [SerializeField] Text mutipleText;//倍数显示文本
    [HideInInspector] public int mutiple = 1;//倍数
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        mutipleText.text = mutiple.ToString();
    }
    int score;
    public int Score { get { return score; } }
    public void AddScore(int addCount) => score += addCount * mutiple;//增加分数：分数 * 倍数
}
