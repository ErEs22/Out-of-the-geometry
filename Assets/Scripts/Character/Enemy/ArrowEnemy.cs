using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 直接移动的敌人
/// </summary>
public class ArrowEnemy : Enemy
{
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
}
