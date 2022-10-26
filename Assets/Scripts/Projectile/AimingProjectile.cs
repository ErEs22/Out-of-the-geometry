using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class AimingProjectile : Projectile
{
    [SerializeField] GuidenceSystem guidenceSystem;
    private void OnEnable()
    {
        StartCoroutine(guidenceSystem.MoveWithRadianCoroutine());
    }
    protected override void Update()
    {
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        StopAllCoroutines();
    }
}
