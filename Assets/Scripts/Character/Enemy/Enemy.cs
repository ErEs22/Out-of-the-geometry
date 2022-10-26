using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人类，敌人基本行为
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] protected AudioData dieSFX;
    [Header("---Bonus---")]
    [SerializeField] GameObject bonusPrefab;//奖励道具
    [SerializeField] protected int bonusScore;//奖励分数
    [SerializeField] int bonusAmount;//奖励道具掉落数量
    [Header("---Health---")]
    [SerializeField] public float maxHealth;//最大血量
    [SerializeField] protected GameObject deathVFX;//死亡特效
    [SerializeField] public float currentHealth;//当前血量
    [Header("---Move---")]
    public GuidenceSystem guidenceSystem;//导航系统对象
    public float moveSpeed;//移动速度
    Coroutine moveWithRadianCoroutine;//进行导航的携程
    protected LevelController levelController;
    protected virtual void OnEnable()
    {
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        //moveWithRadianCoroutine = StartCoroutine(guidenceSystem.MoveWithRadianCoroutine(guidenceSystem.GetNewRandomPosition()));//当目标激活时，开始导航
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && (gameObject.tag == "Enemy" || gameObject.tag == "Boss"))
        {
            switch (GameManager.Instance.currentLevel)
            {
                case 1:
                    StartCoroutine(LevelController.Instance.ReBirthPlayerCoroutine());
                    break;
                case 2:
                    StartCoroutine(LevelController.Instance.ReBirthPlayerCoroutine());
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("LevelController").GetComponent<Level03Controller>().isBonusTime = false;
                    StartCoroutine(LevelController.Instance.ReBirthPlayerCoroutine());
                    break;
                case 4:
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()?.Die();
                    GameManager.Instance.StartGameOverCoroutine();
                    break;
                case 5:
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()?.Die();
                    GameManager.Instance.StartGameOverCoroutine();
                    break;
                default: break;
            }
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void Move() => GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;//敌人的移动
    public virtual void Die()
    {
        AudioManager.Instance.PlaySFX(dieSFX);
        ScoreManager.Instance.mutiple++;//增加分数倍数
        gameObject.SetActive(false);
        ScoreManager.Instance.AddScore(bonusScore);//添加分数
        PoolManager.Release(deathVFX, transform.position, Quaternion.identity);
        Bonus();
    }
    public void Explode()//清除敌人，没有奖励
    {
        PoolManager.Release(deathVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    void Bonus()//根据奖励道具的数量来生成奖励道具
    {
        for (var i = 0; i < bonusAmount; i++)
        {
            PoolManager.Release(bonusPrefab, transform.position, Quaternion.identity);
        }
    }
}
