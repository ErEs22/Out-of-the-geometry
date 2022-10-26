using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class Level05Controller : LevelController
{
    [SerializeField] GameObject[] OutSide;
    [SerializeField] GameObject[] BossPawnPositions;
    public Coroutine generateEnemyCoroutine;
    protected override void Awake()
    {
        base.Awake();
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
            GenerateEnemys(BossPawnPositions, objectList[Tool.GetRandomNumber(0, objectList.Length)]);
            yield return new WaitForSeconds(4);
            GenerateEnemys(BossPawnPositions, objectList[Tool.GetRandomNumber(0, objectList.Length)]);
            yield return new WaitForSeconds(4);
            GenerateEnemys(OutSide, objectList[Tool.GetRandomNumber(0, objectList.Length)]);
            yield return new WaitForSeconds(4);
        }
    }
}
