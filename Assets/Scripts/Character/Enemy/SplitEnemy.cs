using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 分裂敌人
/// </summary>
public class SplitEnemy : Enemy
{
    [SerializeField] GameObject childPrefab;//分裂的物体预制体
    [SerializeField] int splitNumber;//分裂数量
    protected override void OnEnable()
    {
        base.OnEnable();
        if (levelController.levelShape == LevelController.eLevelShape.Rect)
        {
            StartCoroutine(guidenceSystem.MoveInRectCoroutine(guidenceSystem.GetNewRandomPosition()));
        }
        else if (levelController.levelShape == LevelController.eLevelShape.Circle)
        {
            StartCoroutine(guidenceSystem.MoveInCircleCoroutine(guidenceSystem.GetNewCircleRandomPosition()));
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public override void Die()
    {
        PoolManager.Release(deathVFX, transform.position, Quaternion.identity);//释放死亡效果
        for (var i = 0; i < splitNumber; i++)//根据分裂数量生成分裂体
        {
            Vector3 splitPos = new Vector3(gameObject.transform.position.x, 1.35f, gameObject.transform.position.z);
            PoolManager.Release(childPrefab, splitPos, Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}
