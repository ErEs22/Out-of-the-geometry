using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class BossBrith : Birth
{
    GameObject boss;
    protected override void OnEnable()
    {
        base.OnEnable();
        boss = GameObject.FindGameObjectWithTag("BossParent");
    }
    protected override IEnumerator BirthCoroutine()//重写的重生携程，设置玩家为激活，而不是新生成一个
    {
        yield return new WaitForSeconds(birthDelayTime);
        boss.GetComponentInChildren<Boss>(true).gameObject.SetActive(true);
        // Resources.FindObjectsOfTypeAll<Boss>()[0].gameObject.SetActive(true);
    }
}
