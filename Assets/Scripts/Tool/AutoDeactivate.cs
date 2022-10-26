using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自动销毁类
/// </summary>
public class AutoDeactivate : MonoBehaviour
{
    [SerializeField] bool isDestroy;//是否销毁
    [SerializeField] float waitDestroyTime = 2f;//销毁等待时间
    WaitForSeconds waitForDestroy;
    private void Awake()
    {
        waitForDestroy = new WaitForSeconds(waitDestroyTime);
    }
    private void OnEnable()
    {
        StartCoroutine(nameof(DestroyGameObject));
    }

    IEnumerator DestroyGameObject()
    {
        yield return waitForDestroy;
        if (isDestroy)//如果为true销毁，否则禁用对象
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
