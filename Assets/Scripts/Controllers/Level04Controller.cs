using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class Level04Controller : LevelController
{
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
            RandomGenerateEnemys(birthPositions);
            yield return new WaitForSeconds(5);
        }
    }
}
