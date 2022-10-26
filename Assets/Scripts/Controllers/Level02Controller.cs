using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡2控制器
/// </summary>
public class Level02Controller : LevelController
{
    [SerializeField] GameObject[] leftVertical;
    [SerializeField] GameObject[] rightVertical;
    [SerializeField] GameObject[] bottomHorizontal;
    [SerializeField] GameObject[] topHorizontal;
    [SerializeField] GameObject[] leftBlock;
    [SerializeField] GameObject[] rightBlock;
    [SerializeField] GameObject[] corner;
    public Coroutine generateEnemyCoroutine;
    WaitUntil waitEnemyClear;
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
        GenerateEnemys(leftVertical, objectList[3]);
        yield return waitEnemyClear;
        GenerateEnemys(rightVertical, objectList[7]);
        yield return waitEnemyClear;
        GenerateEnemys(leftBlock, objectList[3]);
        yield return waitEnemyClear;
        GenerateEnemys(rightBlock, objectList[7]);
        yield return waitEnemyClear;
        GenerateEnemys(topHorizontal, objectList[3]);
        yield return waitEnemyClear;
        GenerateEnemys(bottomHorizontal, objectList[6]);
        yield return waitEnemyClear;
        GenerateEnemys(leftBlock, objectList[7]);
        GenerateEnemys(rightBlock, objectList[3]);
        yield return waitEnemyClear;
        GenerateEnemys(leftVertical, objectList[1]);
        GenerateEnemys(rightVertical, objectList[1]);
        yield return waitEnemyClear;
        GenerateEnemys(topHorizontal, objectList[7]);
        GenerateEnemys(bottomHorizontal, objectList[7]);
        yield return waitEnemyClear;
        GenerateEnemys(leftBlock, objectList[2]);
        yield return waitEnemyClear;
        GenerateEnemys(rightBlock, objectList[2]);
        yield return waitEnemyClear;
        for (var i = 0; i < 12; i++)
        {
            GenerateEnemys(corner, objectList[8]);
        }
        yield return waitEnemyClear;
        GenerateEnemys(topHorizontal, objectList[1]);
        GenerateEnemys(bottomHorizontal, objectList[1]);
        GenerateEnemys(leftVertical, objectList[1]);
        GenerateEnemys(rightVertical, objectList[1]);
        yield return waitEnemyClear;
        for (var i = 0; i < 10; i++)
        {
            GenerateEnemys(corner, objectList[7]);
        }
        yield return new WaitForSeconds(3);
        GenerateEnemys(leftBlock, objectList[7]);
        GenerateEnemys(rightBlock, objectList[7]);
        yield return waitEnemyClear;
        GenerateEnemys(topHorizontal, objectList[7]);
        GenerateEnemys(bottomHorizontal, objectList[7]);
        yield return waitEnemyClear;
        GenerateEnemys(leftBlock, objectList[1]);
        GenerateEnemys(rightVertical, objectList[2]);
        yield return waitEnemyClear;
        GenerateEnemys(rightBlock, objectList[2]);
        GenerateEnemys(leftVertical, objectList[1]);
        yield return waitEnemyClear;
        GenerateEnemys(topHorizontal, objectList[3]);
        GenerateEnemys(bottomHorizontal, objectList[3]);
        yield return waitEnemyClear;
        GenerateEnemys(leftBlock, objectList[1]);
        GenerateEnemys(rightBlock, objectList[1]);
        yield return new WaitForSeconds(3);
        for (var i = 0; i < 10; i++)
        {
            GenerateEnemys(corner, objectList[7]);
        }
        for (var i = 0; i < 10; i++)
        {
            GenerateEnemys(corner, objectList[8]);
        }
        yield return waitEnemyClear;
        GenerateEnemys(leftVertical, objectList[1]);
        GenerateEnemys(rightVertical, objectList[1]);
        GenerateEnemys(topHorizontal, objectList[1]);
        GenerateEnemys(bottomHorizontal, objectList[1]);
        yield return waitEnemyClear;
        while (true)
        {
            GenerateEnemys(topHorizontal, objectList[7]);
            GenerateEnemys(bottomHorizontal, objectList[7]);
            yield return waitEnemyClear;
            GenerateEnemys(leftBlock, objectList[2]);
            yield return waitEnemyClear;
            GenerateEnemys(rightBlock, objectList[2]);
            yield return waitEnemyClear;
            GenerateEnemys(corner, objectList[8]);
            yield return waitEnemyClear;
            GenerateEnemys(topHorizontal, objectList[1]);
            GenerateEnemys(bottomHorizontal, objectList[1]);
            GenerateEnemys(leftVertical, objectList[1]);
            GenerateEnemys(rightVertical, objectList[1]);
            yield return waitEnemyClear;
            for (var i = 0; i < 10; i++)
            {
                GenerateEnemys(corner, objectList[7]);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
