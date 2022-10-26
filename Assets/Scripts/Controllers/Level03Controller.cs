using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡2控制器
/// </summary>
public class Level03Controller : LevelController
{
    [SerializeField] GameObject[] defaultPositions;
    public Coroutine generateEnemyCoroutine;
    WaitUntil waitEnemyClear;
    [HideInInspector] public bool isBonusTime;
    protected override void Awake()
    {
        base.Awake();
        waitEnemyClear = new WaitUntil(IsEnemyClear);
    }
    private void OnEnable()
    {
        generateEnemyCoroutine = StartCoroutine(nameof(GenerateEnemyFlowCoroutine));
    }
    private void OnDisable()
    {
        StopCoroutine(generateEnemyCoroutine);
    }
    public override void StopGenerateEnemyCoroutine()
    {
        StopCoroutine(generateEnemyCoroutine);
    }
    public IEnumerator GenerateEnemyFlowCoroutine()//关卡敌人生成顺序携程
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            GenerateEnemys(defaultPositions, objectList[Tool.GetRandomNumber(0, objectList.Length)]);
            isBonusTime = true;
            yield return waitEnemyClear;
            if (isBonusTime)
            {
                TimeController.Instance.seconds += 15;
            }
        }
    }
}
