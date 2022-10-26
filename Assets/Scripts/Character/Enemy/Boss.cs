using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Boss
/// </summary>
public class Boss : Enemy
{
    [SerializeField] GameObject shield;
    [SerializeField] int lifeCount;
    [SerializeField] int maxHPPerLife;
    [SerializeField] Image frontImage;
    [SerializeField] Image backImage;
    int currentHP;
    protected override void OnEnable()
    {
        base.OnEnable();
        currentHP = maxHPPerLife;
        UpdateHealthBar();
        StartCoroutine(ShieldVanishCoroutine());
        if (levelController.levelShape == LevelController.eLevelShape.Rect)
        {
            StartCoroutine(guidenceSystem.MoveInRectCoroutine(guidenceSystem.GetNewRandomPosition()));
        }
        else if (levelController.levelShape == LevelController.eLevelShape.Circle)
        {
            StartCoroutine(guidenceSystem.MoveInCircleCoroutine(guidenceSystem.GetNewCircleRandomPosition()));
        }
    }
    void UpdateHealthBar()
    {
        frontImage.fillAmount = (float)currentHP / (float)maxHPPerLife;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void ReStoreHealth()
    {
        currentHP = maxHPPerLife;
    }
    public void TakeDamage()
    {
        currentHP--;
        UpdateHealthBar();
        if (currentHP == 0)
        {
            if (lifeCount == 0)
            {
                Die();
            }
            else
            {
                lifeCount--;
                ReStoreHealth();
                TimeController.Instance.seconds += 30;
                shield.SetActive(true);
                StartCoroutine(ShieldVanishCoroutine());
            }
            if (lifeCount == 3)
            {
                StopAllCoroutines();
                StartCoroutine(ShieldVanishCoroutine());
                StartCoroutine(MoveToCenterCoroutine());
            }
            if (lifeCount == 1)
            {
                moveSpeed *= 1.5f;
                if (levelController.levelShape == LevelController.eLevelShape.Rect)
                {
                    StartCoroutine(guidenceSystem.MoveInRectCoroutine(guidenceSystem.GetNewRandomPosition()));
                }
                else if (levelController.levelShape == LevelController.eLevelShape.Circle)
                {
                    StartCoroutine(guidenceSystem.MoveInCircleCoroutine(guidenceSystem.GetNewCircleRandomPosition()));
                }
            }
            if (lifeCount == 0)
            {
                moveSpeed *= 1.5f;
            }
        }
    }
    new void Die()
    {
        AudioManager.Instance.PlaySFX(dieSFX);
        PoolManager.Release(deathVFX, transform.position, Quaternion.identity);
        ScoreManager.Instance.AddScore(bonusScore);//添加分数
        GameManager.Instance.StartGameOverCoroutine();
        gameObject.SetActive(false);
    }
    IEnumerator ShieldVanishCoroutine()
    {
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
    }
    IEnumerator MoveToCenterCoroutine()
    {
        Vector3 moveDir = Vector3.zero;
        while (true)
        {
            moveDir = new Vector3(0, transform.position.y, 0) - transform.position;
            transform.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
            Move();
            if (Vector3.Distance(transform.position, new Vector3(0, transform.position.y, 0)) < 0.1)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
