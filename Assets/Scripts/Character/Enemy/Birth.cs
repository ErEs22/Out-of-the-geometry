using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 重生类
/// </summary>
public class Birth : MonoBehaviour
{
    [SerializeField] GameObject birthPrefab;//重生特效
    [SerializeField] protected float birthDelayTime;//重生延迟时间
    protected virtual void OnEnable()
    {
        StartCoroutine(nameof(BirthCoroutine));
    }
    protected virtual void OnDisable()
    {
        StopCoroutine(nameof(BirthCoroutine));
    }
    protected virtual IEnumerator BirthCoroutine()//等待延迟时间过后生成对象
    {
        yield return new WaitForSeconds(birthDelayTime);
        PoolManager.Release(birthPrefab, transform.position, Quaternion.identity);
    }
}
