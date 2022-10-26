using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 游戏中的指引系统，如寻路，追踪目标
/// </summary>
public class GuidenceSystem : MonoBehaviour
{
    enum eObjectType//目标类型
    {
        Enemy,
        Bullet
    }
    [SerializeField] GameObject guidenceObject;//追踪目标
    [SerializeField] float randomXOffset;//随机移动x偏移量
    [SerializeField] float randomZOffset;//随机移动y偏移量
    [SerializeField] float minBallisticAngle;//随机旋转最小偏移角度
    [SerializeField] float maxBallisticAngle;//随机旋转最大偏移角度
    [SerializeField] float stopDistance;//获取下一个移动目标的最大距离
    [SerializeField] float stopChasingDistance;//停止追踪玩家最大距离
    [SerializeField] float speedAccValue;//速度增加的距离阈值
    [SerializeField] float waitAimTime;//等待瞄准时间
    [SerializeField] bool chaseFormStart;//是否生成就追踪玩家
    [SerializeField] eObjectType objectType;//该目标的类型
    GameObject player;//场景中的玩家
    LevelController levelController;//关卡控制器
    float ballisticAngle;//偏移角度
    Vector3 targetDirection;//目标方向
    void OnEnable()
    {
        levelController = FindObjectOfType<LevelController>();
        player = GameObject.FindGameObjectWithTag("Player");//根据tag找到player
    }
    void Move(float moveSpeed) => GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;//敌人的移动
    GameObject FindClosetEnemy()//寻找最近的敌人
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float dis = 1000;
        GameObject returnEnemy = null;
        foreach (var enemy in enemys)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < dis)
            {
                dis = Vector3.Distance(transform.position, enemy.transform.position);
                returnEnemy = enemy;
            }
        }
        return returnEnemy;
    }
    /// <summary>
    /// 获取新的随机位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetNewRandomPosition()
    {
        Vector3 newPosition = NewRandomPosition();
        newPosition.y = 1.35f;//固定随机位置的y轴位置
        while (!levelController.LimitArea(newPosition))//如果不在限制范围内，则重新获取位置
        {
            newPosition = NewRandomPosition();
        }
        return newPosition;//返回
    }
    public Vector3 GetNewCircleRandomPosition()
    {
        Vector3 newPosition = NewRandomPosition();
        newPosition.y = 1.35f;//固定随机位置的y轴位置
        while (!levelController.LimitAreaCircle(newPosition))//如果不在限制范围内，则重新获取位置!levelController.LimitAreaCircle(newPosition)
        {
            newPosition = NewRandomPosition();
        }
        return newPosition;//返回
    }
    void MoveForDiffType(eObjectType type)
    {
        switch (type)//根据导航对象的类型，各自实现移动
        {
            case eObjectType.Enemy:
                guidenceObject.GetComponent<Enemy>().Move();
                break;
            case eObjectType.Bullet:
                guidenceObject.GetComponent<Projectile>().Move();
                break;
            default: break;
        }
    }
    Vector3 NewRandomPosition()
    {
        Vector3 newPosition = Vector3.zero;
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)//一半的几率选中随机位置中的竖向位置
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)//一半的几率选中x的偏移量的负值或正值
            {
                newPosition.x = transform.position.x - randomXOffset;
            }
            else
            {
                newPosition.x = transform.position.x + randomXOffset;
            }
            newPosition.z = UnityEngine.Random.Range(-randomZOffset, randomZOffset) + transform.position.z;
        }
        else//一半的几率选中随机位置中的横向位置
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)//一半的几率选中z的偏移量的负值或正值
            {
                newPosition.z = transform.position.z - randomZOffset;
            }
            else
            {
                newPosition.z = transform.position.z + randomZOffset;
            }
            newPosition.x = UnityEngine.Random.Range(-randomXOffset, randomXOffset) + transform.position.x;
        }
        return newPosition;
    }
    /// <summary>
    /// 导航到一个目标的位置，并且移动会有一定的弧度
    /// </summary>
    /// <param name="target">导航目标</param>
    /// <returns></returns>
    public IEnumerator MoveWithRadianCoroutine()
    {
        ballisticAngle = UnityEngine.Random.Range(minBallisticAngle, maxBallisticAngle);//随机获取一个旋转偏移量
        float speed = objectType == eObjectType.Enemy ? guidenceObject.GetComponent<Enemy>().moveSpeed : guidenceObject.GetComponent<Projectile>().bulletSpeed;//获取需要导航的对象的移动速度
        while (true)
        {
            if (waitAimTime >= 1f)
            {
                waitAimTime = 0;
                break;
            }
            else
            {
                MoveForDiffType(objectType);
                waitAimTime += Time.fixedDeltaTime;
            }
            yield return null;
        }
        GameObject target = FindClosetEnemy();
        while (true)
        {
            if (target != null)//当目标存在时，才进行导航
            {
                if (target.activeSelf)
                {
                    if (Vector3.Distance(target.transform.position, transform.position) >= speed * Time.fixedDeltaTime)//当对象基本接近目标之前，进行导航
                    {
                        targetDirection = target.transform.position - transform.position;//导航目标和对象的位置向量
                        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg, Vector3.up);//将对象进行旋转，z轴对向目标
                        transform.rotation *= Quaternion.Euler(0f, ballisticAngle, 0f);//进行旋转偏移，增加旋转偏移角度，让对象可以实现曲线移动
                        MoveForDiffType(objectType);
                    }
                }
                else
                {
                    MoveForDiffType(objectType);
                }
            }
            else
            {
                MoveForDiffType(objectType);
            }
            yield return new WaitForFixedUpdate();//固定帧进行更新
        }
    }
    /// <summary>
    /// 导航到一个点的位置，并且移动会有一定的弧度,会追踪玩家
    /// </summary>
    /// <param name="targetT">导航目标点</param>
    /// <returns></returns>
    public IEnumerator MoveInRectCoroutine(Vector3 targetP)
    {
        float reDirectTime = 0f;
        ballisticAngle = UnityEngine.Random.Range(minBallisticAngle, maxBallisticAngle);//随机获取一个旋转偏移量
        float speed = objectType == eObjectType.Enemy ? guidenceObject.GetComponent<Enemy>().moveSpeed : guidenceObject.GetComponent<Projectile>().bulletSpeed;//获取需要导航的对象的移动速度
        while (true)
        {
            reDirectTime += Time.fixedDeltaTime;
            if (player != null)
            {
                if ((Vector3.Distance(player.transform.position, transform.position) <= stopChasingDistance && player != null) || chaseFormStart)//如果到达需要追踪目标的距离或从生成就追踪目标，进行目标追踪
                {
                    Vector3 playerPos = new Vector3(player.transform.position.x, 1.35f, player.transform.position.z);
                    targetDirection = playerPos - transform.position;//导航目标和对象的位置向量
                    GetComponent<Rigidbody>().velocity = targetDirection.normalized * speed;//向目标移动
                }
                else
                {
                    if (Vector3.Distance(targetP, transform.position) >= stopDistance && reDirectTime <= 3f)//当对象基本接近目标之前，进行导航
                    {
                        targetDirection = targetP - transform.position;//导航目标和对象的位置向量
                        //transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg, Vector3.up);//将对象进行旋转，z轴对向目标
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg, Vector3.up), 0.1f);
                        //transform.rotation *= Quaternion.Euler(0f, ballisticAngle, 0f);//进行旋转偏移，增加旋转偏移角度，让对象可以实现曲线移动
                        MoveForDiffType(objectType);
                    }
                    else
                    {
                        reDirectTime = 0f;
                        targetP = GetNewRandomPosition();//如果导航对象到达了目标点，则更新目标点，继续向目标点移动
                        ballisticAngle = UnityEngine.Random.Range(minBallisticAngle, maxBallisticAngle);//获取一个新的旋转偏移量
                    }
                }
            }
            yield return new WaitForFixedUpdate();//固定帧进行更新
        }
    }
    /// <summary>
    /// 在圆圈内移动携程
    /// </summary>
    /// <param name="targetP">初始移动目标点</param>
    /// <returns></returns>
    public IEnumerator MoveInCircleCoroutine(Vector3 targetP)
    {
        float reDirectTime = 0f;
        ballisticAngle = UnityEngine.Random.Range(minBallisticAngle, maxBallisticAngle);//随机获取一个旋转偏移量
        float speed = objectType == eObjectType.Enemy ? guidenceObject.GetComponent<Enemy>().moveSpeed : guidenceObject.GetComponent<Projectile>().bulletSpeed;//获取需要导航的对象的移动速度
        while (true)
        {
            reDirectTime += Time.fixedDeltaTime;
            if (player != null)
            {
                if ((Vector3.Distance(player.transform.position, transform.position) <= stopChasingDistance && player != null) || chaseFormStart)//如果到达需要追踪目标的距离或从生成就追踪目标，进行目标追踪
                {
                    Vector3 playerPos = new Vector3(player.transform.position.x, 1.35f, player.transform.position.z);
                    targetDirection = playerPos - transform.position;//导航目标和对象的位置向量
                    GetComponent<Rigidbody>().velocity = targetDirection.normalized * speed;//向目标移动
                }
                else
                {
                    if (Vector3.Distance(targetP, transform.position) >= stopDistance && reDirectTime <= 3f)//当对象基本接近目标之前，进行导航
                    {
                        targetDirection = targetP - transform.position;//导航目标和对象的位置向量
                        //transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg, Vector3.up);//将对象进行旋转，z轴对向目标
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg, Vector3.up), 0.1f);
                        //transform.rotation *= Quaternion.Euler(0f, ballisticAngle, 0f);//进行旋转偏移，增加旋转偏移角度，让对象可以实现曲线移动
                        MoveForDiffType(objectType);
                    }
                    else
                    {
                        reDirectTime = 0f;
                        targetP = GetNewCircleRandomPosition();//如果导航对象到达了目标点，则更新目标点，继续向目标点移动
                        ballisticAngle = UnityEngine.Random.Range(minBallisticAngle, maxBallisticAngle);//获取一个新的旋转偏移量
                    }
                }
            }
            yield return new WaitForFixedUpdate();//固定帧进行更新
        }
    }
    /// <summary>
    /// 导航到一个点，直接移动，不进行旋转偏移,并不会追踪玩家
    /// </summary>
    /// <param name="targetP">目标点</param>
    /// <returns></returns>
    public IEnumerator MoveDirectilyCoroutine(Vector3 targetP)//直接移动，不进行旋转偏移
    {
        float speed = objectType == eObjectType.Enemy ? guidenceObject.GetComponent<Enemy>().moveSpeed : guidenceObject.GetComponent<Projectile>().bulletSpeed;//获取需要导航的对象的移动速度
        while (true)
        {
            if (Vector3.Distance(transform.position, targetP) >= speed * Time.fixedDeltaTime)
            {
                transform.LookAt(targetP, Vector3.up);//让对象朝向目标点
                guidenceObject.GetComponent<Enemy>().Move();//让对象开始移动
            }
            else
            {
                targetP = GetNewRandomPosition();//接近目标点就获取一个新的目标
            }
            yield return new WaitForFixedUpdate();
        }
    }
    /// <summary>
    /// 角色直接向玩家移动，如果玩家朝向物体，则会后退，否则向玩家移动
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveToOrAwayToTarget()
    {
        float speed = objectType == eObjectType.Enemy ? guidenceObject.GetComponent<Enemy>().moveSpeed : guidenceObject.GetComponent<Projectile>().bulletSpeed;
        while (true)
        {
            if (player == null)
            {
                yield break;
            }
            // float currentSpeed = Mathf.Clamp(speed * (Vector3.Distance(player.transform.position, transform.position) / speedAccValue), speed, speed * 3f);
            float currentSpeed = speed * 2f;
            Vector3 playerPos = new Vector3(player.transform.position.x, 1.35f, player.transform.position.z);
            targetDirection = playerPos - transform.position;//移动的方向
            if (Vector3.Angle(targetDirection, player.transform.forward) > 135)//如果玩家的前方90°内有该敌人，则向反方向移动，没有则向玩家移动
            {
                transform.rotation = Quaternion.LookRotation(targetDirection * -1);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
            Move(currentSpeed);//移动
            yield return new WaitForFixedUpdate();
        }
    }
}
