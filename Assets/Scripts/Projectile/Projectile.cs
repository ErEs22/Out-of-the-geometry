using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹类，子弹基本行为
/// </summary>
public class Projectile : MonoBehaviour
{
    public float bulletSpeed;//子弹速度
    [SerializeField] GameObject explodeVFX;
    [SerializeField] GameObject shieldExplodeVFX;
    [SerializeField] AudioData hitSFX;
    TrailRenderer trail;//子弹尾迹
    protected GameObject player;
    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trail = GetComponentInChildren<TrailRenderer>();//在孩子中获取尾迹渲染器组件
    }
    protected virtual void OnDisable()
    {
        trail.Clear();//当禁用目标时，清除尾迹
    }
    protected virtual void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PoolManager.Release(explodeVFX, transform.position, Quaternion.Euler(transform.rotation.eulerAngles * -1));
            gameObject.SetActive(false);
            other.GetComponent<Enemy>()?.Die();
        }
        if (other.tag == "Block")
        {
            AudioManager.Instance.PlaySFX(hitSFX);
            PoolManager.Release(shieldExplodeVFX, transform.position, Quaternion.Euler(transform.rotation.eulerAngles * -1));
            gameObject.SetActive(false);
        }
        if (other.tag == "Boss")
        {
            AudioManager.Instance.PlaySFX(hitSFX);
            PoolManager.Release(explodeVFX, transform.position, Quaternion.Euler(transform.rotation.eulerAngles * -1));
            other.GetComponent<Boss>().TakeDamage();
            gameObject.SetActive(false);
        }
    }
    public void Move() => transform.Translate(transform.forward * bulletSpeed * Time.deltaTime, Space.World);//子弹移动
}
