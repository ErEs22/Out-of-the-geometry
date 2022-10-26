using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class Level01Controller : LevelController
{
    [SerializeField] GameObject[] OutSidePoints;//外圈生成点
    [SerializeField] GameObject[] InSidePoints;//内圈生成点
    [SerializeField] GameObject[] VerticalLinePoints;//竖直生成点
    [SerializeField] GameObject[] HorizontalLinePoints;//水平生成点
    [SerializeField] GameObject[] MiddlePoints;//圈中间生成点
    [SerializeField] GameObject[] CirclePoints;//圆心生成点
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
        GenerateEnemys(OutSidePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(OutSidePoints, objectList[6]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(InSidePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(VerticalLinePoints, objectList[6]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(OutSidePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(HorizontalLinePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(MiddlePoints, objectList[6]);
        GenerateEnemys(OutSidePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(VerticalLinePoints, objectList[4]);
        GenerateEnemys(CirclePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(HorizontalLinePoints, objectList[6]);
        GenerateEnemys(VerticalLinePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(OutSidePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(InSidePoints, objectList[1]);
        GenerateEnemys(OutSidePoints, objectList[6]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(HorizontalLinePoints, objectList[6]);
        GenerateEnemys(VerticalLinePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(OutSidePoints, objectList[4]);
        GenerateEnemys(MiddlePoints, objectList[1]);
        yield return new WaitForSeconds(3);
        GenerateEnemys(HorizontalLinePoints, objectList[6]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(MiddlePoints, objectList[1]);
        GenerateEnemys(OutSidePoints, objectList[4]);
        yield return new WaitForSeconds(3);
        GenerateEnemys(VerticalLinePoints, objectList[6]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(OutSidePoints, objectList[6]);
        GenerateEnemys(MiddlePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(HorizontalLinePoints, objectList[1]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(MiddlePoints, objectList[6]);
        GenerateEnemys(OutSidePoints, objectList[4]);
        yield return new WaitUntil(IsEnemyClear);
        GenerateEnemys(HorizontalLinePoints, objectList[6]);
        GenerateEnemys(VerticalLinePoints, objectList[1]);
        yield return new WaitForSeconds(5);
        while (true)//在关卡后半段进行重复生成
        {
            GenerateEnemys(OutSidePoints, objectList[1]);
            yield return new WaitUntil(IsEnemyClear);
            GenerateEnemys(OutSidePoints, objectList[6]);
            yield return new WaitUntil(IsEnemyClear);
            GenerateEnemys(InSidePoints, objectList[1]);
            yield return new WaitUntil(IsEnemyClear);
            GenerateEnemys(VerticalLinePoints, objectList[6]);
            yield return new WaitUntil(IsEnemyClear);
            GenerateEnemys(HorizontalLinePoints, objectList[1]);
            yield return new WaitUntil(IsEnemyClear);
            GenerateEnemys(VerticalLinePoints, objectList[4]);
            GenerateEnemys(CirclePoints, objectList[4]);
            GenerateEnemys(HorizontalLinePoints, objectList[6]);
            yield return new WaitForSeconds(5);
        }
    }
}
