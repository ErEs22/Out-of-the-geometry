using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家过载类
/// </summary>
public class PlayerOverDrive : MonoBehaviour
{
    [SerializeField] float overDriveTime;//强化时间
    [SerializeField] PlayerController playerController;
    public IEnumerator OverDriveCoroutine()//强化玩家子弹，等待强化时间过后结束
    {
        playerController.Aiming = true;
        yield return new WaitForSeconds(overDriveTime);
        playerController.Aiming = false;
    }
}
