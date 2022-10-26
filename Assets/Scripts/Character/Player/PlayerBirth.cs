using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家生成
/// </summary>
public class PlayerBirth : Birth
{
    GameObject player;
    protected override void OnEnable()
    {
        base.OnEnable();
        player = GameObject.FindGameObjectWithTag("PlayerParent");
    }
    protected override IEnumerator BirthCoroutine()//重写的重生携程，设置玩家为激活，而不是新生成一个
    {
        yield return new WaitForSeconds(birthDelayTime);
        player.GetComponentInChildren<PlayerController>(true).gameObject.SetActive(true);
        // Resources.FindObjectsOfTypeAll<PlayerController>()[0].gameObject.SetActive(true);
    }
}
