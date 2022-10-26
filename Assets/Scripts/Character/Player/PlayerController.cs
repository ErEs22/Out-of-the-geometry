using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家角色控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;//玩家的输入脚本
    [SerializeField] GameObject normalProjectilePrefab;//普通子弹
    [SerializeField] GameObject aimingProjectilePrefab;//自动瞄准子弹
    [SerializeField] GameObject deathVFXPrefab;//死亡特效
    [SerializeField] Transform muzzlePoint;//开火点
    [SerializeField] AudioData fireData;
    [SerializeField] float moveSpeed;//玩家移动速度
    [SerializeField] float fireMoveSpeed;//开火时的移动速度
    [SerializeField] float fireInterval;//开火间隔时间
    [SerializeField] float bulletOffsetAngle;//子弹发射角度偏移
    [SerializeField] public bool Aiming;//是否开启自动瞄准子弹
    [SerializeField, Range(1, 10)] int rotationSpeed;//旋转速度
    Coroutine moveCoroutine;//移动的携程
    Coroutine fireCoroutine;//开火的携程
    Coroutine AnChangeCoroutine;//动画切换携程
    Animator playerAnimator;//玩家的动画器
    Rigidbody playerRig;//玩家的刚体
    // LevelController levelController;//关卡控制器
    Vector3 moveDirection;//玩家移动方向
    Quaternion moveRotation;//玩家的旋转
    RaycastHit hit;//激光击中点的信息
    Ray ray;//控制开火方向的激光
    float currentMoveSpeed;//当前移动速度
    float fireWaitTime;//开火冷却时间
    bool firing;//玩家当前是否处于开火状态
    // Quaternion currentRotation;
    void Awake()
    {
        // levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        playerAnimator = GetComponent<Animator>();//获取玩家的动画器组件
        playerRig = GetComponent<Rigidbody>();//获取玩家的刚体组件
    }
    void OnEnable()
    {
        playerRig.velocity = Vector3.zero;
        //绑定移动开火的事件方法
        playerInput.onMove += OnMove;
        playerInput.onStopMove += OnStopMove;
        playerInput.onFire += OnFire;
        playerInput.onStopFire += OnStopFire;
        // Cursor.visible = false;
    }
    void OnDisable()
    {
        //取消绑定移动开火的事件方法
        playerInput.onMove -= OnMove;
        playerInput.onStopMove -= OnStopMove;
        playerInput.onFire -= OnFire;
        playerInput.onStopFire -= OnStopFire;
    }
    void OnMove(Vector2 playerInput)//playerInput为玩家的二维输入
    {
        currentMoveSpeed = moveSpeed;//设置当前移动速度为正常移动时的速度
        //将玩家的输入变为移动的方向
        moveDirection.x = playerInput.x;
        moveDirection.z = playerInput.y;
        if (moveCoroutine != null)//如果移动携程不为空，则停止携程，防止多个携程同时执行，占用资源
        {
            StopCoroutine(moveCoroutine);
        }
        if (AnChangeCoroutine != null)//如果动画切换携程不为空，则停止携程，防止多个携程同时执行，占用资源
        {
            StopCoroutine(AnChangeCoroutine);
        }
        if (firing && playerInput != Vector2.zero)//如果玩家正在开火且正在移动，则该表移动速度为开火移动速度，并启动动画切换携程
        {
            currentMoveSpeed = fireMoveSpeed;
            AnChangeCoroutine = StartCoroutine(FireAnimationChangeCoroutine(moveDirection));
        }
        playerAnimator.SetBool("isRun", true);//切换到跑步动画
        moveRotation = Quaternion.LookRotation(moveDirection);//获取移动方向的四元数
        moveCoroutine = StartCoroutine(MoveCoroutine(moveDirection, currentMoveSpeed, moveRotation));//启动移动携程
    }
    void OnStopMove()//玩家松开移动按键调用
    {
        if (moveCoroutine != null)//如果移动携程不为空，则停止携程，防止多个携程同时执行，占用资源
        {
            StopCoroutine(moveCoroutine);
        }
        if (AnChangeCoroutine != null)//如果动画切换携程不为空，则停止携程，防止多个携程同时执行，占用资源
        {
            StopCoroutine(AnChangeCoroutine);
        }
        playerRig.velocity = Vector3.zero;//设置移动速度为零
        playerAnimator.SetBool("isRun", false);//将动画切换至站立
    }
    void OnFire()//玩家按下开火键调用
    {
        currentMoveSpeed = fireMoveSpeed;//设置当前移动速度为开火时的移动速度
        firing = true;//玩家正在开火
        if (fireCoroutine != null)//如果开火携程不为空，则停止携程，防止多次启动携程，占用资源
        {
            StopCoroutine(fireCoroutine);
        }
        AnChangeCoroutine = StartCoroutine(FireAnimationChangeCoroutine(playerRig.velocity.normalized));//启动玩家动画切换携程
        fireCoroutine = StartCoroutine(FireCoroutine());//启动开火携程
        playerAnimator.SetBool("Fire", true);//切换至开火动画或移动开火动画
    }
    void OnStopFire()//玩家松开开火键调用
    {
        currentMoveSpeed = moveSpeed;//设置当前移动速度为正常情况下的移动速度
        firing = false;//玩家停止开火
        if (fireCoroutine != null)//如果开火携程不为空，则停止携程，防止多次启动携程，占用资源
        {
            StopCoroutine(fireCoroutine);
        }
        if (AnChangeCoroutine != null)//如果动画切换携程不为空，则停止携程，防止多次启动携程，占用资源
        {
            StopCoroutine(AnChangeCoroutine);
        }
        //将玩家的开火状态转成移动或站立
        playerAnimator.SetBool("Fire", false);
        playerAnimator.SetBool("Front_Fire", false);
        playerAnimator.SetBool("Left_Fire", false);
        playerAnimator.SetBool("Right_Fire", false);
        playerAnimator.SetBool("Back_Fire", false);
    }
    public void Die()//玩家死亡
    {
        PoolManager.Release(deathVFXPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    void MoveFireAnimationChange(Vector3 moveDirection)//玩家移动时动画切换
    {
        Vector3 fireDir = MouseManager.Instance.GetMouseHitPosition();//获取鼠标点击的位置向量
        float angle = Vector3.Angle(moveDirection, fireDir);//开火方向和移动方向的夹角
        Vector3 normal = Vector3.Cross(fireDir, moveDirection);//开火方向向量与移动方向向量的×乘，向上为正值，向下为负值
        float dot = Vector3.Dot(Vector3.down, normal);//×乘值与下方向的点乘值，小于90°大于零，大于90°小于零
        if (angle <= 45f)//开火方向与移动方向相同，切换为向前移动开火
        {
            playerAnimator.SetBool("DirectionChange", true);
            playerAnimator.SetBool("Front_Fire", true);
            playerAnimator.SetBool("Left_Fire", false);
            playerAnimator.SetBool("Right_Fire", false);
            playerAnimator.SetBool("Back_Fire", false);
            playerAnimator.SetBool("DirectionChange", false);
        }
        else if (dot > 0 && angle > 45f && angle < 135f)//开火方向与移动方向相同，切换为向左移动开火
        {
            playerAnimator.SetBool("DirectionChange", true);
            playerAnimator.SetBool("Front_Fire", false);
            playerAnimator.SetBool("Left_Fire", true);
            playerAnimator.SetBool("Right_Fire", false);
            playerAnimator.SetBool("Back_Fire", false);
            playerAnimator.SetBool("DirectionChange", false);
        }
        else if (dot < 0 && angle > 45f && angle < 135f)//开火方向与移动方向相同，切换为向右移动开火
        {
            playerAnimator.SetBool("DirectionChange", true);
            playerAnimator.SetBool("Front_Fire", false);
            playerAnimator.SetBool("Left_Fire", false);
            playerAnimator.SetBool("Right_Fire", true);
            playerAnimator.SetBool("Back_Fire", false);
            playerAnimator.SetBool("DirectionChange", false);
        }
        else//开火方向与移动方向相同，切换为向后移动开火
        {
            playerAnimator.SetBool("DirectionChange", true);
            playerAnimator.SetBool("Front_Fire", false);
            playerAnimator.SetBool("Left_Fire", false);
            playerAnimator.SetBool("Right_Fire", false);
            playerAnimator.SetBool("Back_Fire", true);
            playerAnimator.SetBool("DirectionChange", false);
        }
    }
    public void Fire()//发射子弹
    {
        AudioManager.Instance.PlaySFX(fireData);
        float offsetAngle = Tool.GetNumberFromNumbers(bulletOffsetAngle, -bulletOffsetAngle, 0);
        Quaternion offsetRotation = Quaternion.Euler(0, offsetAngle, 0);
        if (Aiming)//如果自动瞄准勾选，则生成自瞄子弹
        {
            PoolManager.Release(aimingProjectilePrefab, muzzlePoint.position, transform.rotation * offsetRotation);
        }
        else
        {
            PoolManager.Release(normalProjectilePrefab, muzzlePoint.position, transform.rotation * offsetRotation);
        }
    }
    IEnumerator FireAnimationChangeCoroutine(Vector3 moveDirection)//开火移动动画切换携程
    {
        while (true)
        {
            MoveFireAnimationChange(moveDirection);//启动开火移动方法
            yield return null;
        }
    }
    IEnumerator MoveCoroutine(Vector3 direction, float speed, Quaternion rotation)//移动携程
    {
        while (true)
        {
            playerRig.velocity = direction.normalized * currentMoveSpeed;//将当前速度赋值给刚体的速度
            if (!firing)//如果不处于开火状态，则玩家朝向移动的方向
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * rotationSpeed);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator FireCoroutine()//开火携程，玩家朝向开火的方向
    {
        fireWaitTime = 0;
        while (true)
        {
            fireWaitTime += Time.deltaTime;
            if (fireWaitTime >= fireInterval)
            {
                fireWaitTime = 0;
                Fire();
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MouseManager.Instance.GetMouseHitPosition().normalized), 0.6f);
            yield return null;
        }
    }
}
