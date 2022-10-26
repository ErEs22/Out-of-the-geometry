using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class GutsEnemy : Enemy
{
    protected override void OnEnable()
    {
        StartCoroutine(guidenceSystem.MoveToOrAwayToTarget());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
