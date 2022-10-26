using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 奖励道具
/// </summary>
public class BonusCube : MonoBehaviour
{
    [SerializeField] int bonusScore;
    public void Die()//死亡增加倍数，分数
    {
        ScoreManager.Instance.mutiple++;
        ScoreManager.Instance.AddScore(bonusScore);
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Die();
        }
    }
}
