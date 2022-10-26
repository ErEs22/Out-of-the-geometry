using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡控制类，控制关卡的进度以及整个流程
/// </summary>
public class LevelController : Singleton<LevelController>
{
    public enum eLevelShape//关卡形状
    {
        Circle,
        Rect
    }
    [SerializeField] AudioData dieData;
    [SerializeField] int mapWidth;//地图宽
    [SerializeField] int mapHeight;//地图高
    [SerializeField] float birthHeight;//生成点高度
    [SerializeField] float birthDisToPlayer;//生成点距离玩家的距离
    [SerializeField] float generateInterval;//生成间距
    [SerializeField] float circleRadius;//圆圈地图的半径
    [SerializeField] bool keepRandomGenerateEnemy;//是否持续随机生成敌人
    public eLevelShape levelShape;
    public GameObject player;//玩家
    [SerializeField] PlayerOverDrive playerOverDrive;
    [SerializeField] GameObject playerRebirth;
    [SerializeField] protected GameObject[] objectList;//关卡生成对象列表
    [SerializeField] protected GameObject[] birthPositions;//随机生成点
    WaitForSeconds waitForGenerateEnemyTime;//等待随机生成时间
    protected override void Awake()
    {
        base.Awake();
        waitForGenerateEnemyTime = new WaitForSeconds(generateInterval);
    }
    private void OnEnable()
    {
        if (keepRandomGenerateEnemy)//如果随机生成，则启动随机生成携程
        {
            StartCoroutine(nameof(KeepRandomGenerateEnemy));
        }
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(KeepRandomGenerateEnemy));
    }
    protected Vector3 GetCertainBirthPosition() => birthPositions[Tool.GetRandomNumber(0, birthPositions.Length)].transform.position;//固定位置的随机生成
    protected Vector3 GetRandomBirthPosition()//随机位置的随机生成
    {
        Vector3 birthPos = RandomPosition();
        while (true)
        {
            if (!IsNearPlayer(birthPos) && LimitArea(birthPos))//生成点不能靠近玩家，并且在限定的区域
            {
                break;
            }
            else
            {
                birthPos = RandomPosition();
            }
        }
        return birthPos;
    }
    public virtual void StopGenerateEnemyCoroutine() { }
    Vector3 RandomPosition()//随机获取一个位置
    {
        int x = Tool.GetRandomNumber(-mapWidth, mapWidth);
        int z = Tool.GetRandomNumber(-mapHeight, mapHeight);
        float y = birthHeight;
        return new Vector3(x, y, z);
    }
    /// <summary>
    /// 根据生成点，生成的敌人类型来生成敌人
    /// </summary>
    /// <param name="pointObject">生成点</param>
    /// <param name="enemy">生成的敌人</param>
    protected void GenerateEnemys(GameObject[] pointObject, GameObject enemy)
    {
        for (var i = 0; i < pointObject.Length; i++)
        {
            PoolManager.Release(enemy, pointObject[i].transform.position, Quaternion.identity);
        }
    }
    protected void RandomGenerateEnemys(GameObject[] pointObject)
    {
        for (var i = 0; i < pointObject.Length; i++)
        {
            PoolManager.Release(objectList[Tool.GetRandomNumber(0, objectList.Length)], pointObject[i].transform.position, Quaternion.identity);
        }
    }
    protected bool IsEnemyClear()//当场景中没有敌人并且玩家是激活的状态时，返回true，否则返回false
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && player.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool IsProjectileBonusClear()//当场景中没有子弹奖励道具并且玩家是激活的状态时，返回true，否则返回false
    {
        if (GameObject.FindGameObjectWithTag("ProjectileBonus") == null && player.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool IsNearPlayer(Vector3 position)//是否靠近玩家
    {
        if (Vector3.Distance(player.transform.position, position) <= birthDisToPlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool LimitArea(Vector3 position)//是否在规定的矩形范围内
    {
        if (Mathf.Abs(position.x) > mapWidth || Mathf.Abs(position.z) > mapHeight)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool LimitAreaLevel02(Vector3 position)
    {
        if (Mathf.Abs(position.x) > mapWidth || Mathf.Abs(position.z) > mapHeight)
        {
            return false;
        }
        else if (false)
        {

        }
        else
        {
            return false;
        }
    }
    public bool LimitAreaCircle(Vector3 position)//是否在规定的圆形范围内
    {
        if (Vector3.Distance(position, Vector3.zero) < circleRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public IEnumerator ReBirthPlayerCoroutine()//玩家重生携程
    {
        player.GetComponent<PlayerController>().Die();
        AudioManager.Instance.PlaySFX(dieData);
        yield return new WaitForSeconds(0.5f);
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))//清除场景的敌人
        {
            enemy.GetComponent<Enemy>()?.Explode();
        }
        // yield return new WaitForSeconds(1.0f);
        PoolManager.Release(playerRebirth, player.transform.position, Quaternion.identity);
    }
    protected IEnumerator ProjectileBonusCoroutine(GameObject[] pointObject, GameObject enemy)//生成子弹奖励携程，生成奖励道具之后等待奖励道具清空，然后玩家就可以发射自瞄子弹
    {
        GenerateEnemys(pointObject, enemy);
        yield return new WaitUntil(IsProjectileBonusClear);
        StartCoroutine(playerOverDrive.OverDriveCoroutine());
    }
    IEnumerator KeepRandomGenerateEnemy()//持续随机生成敌人携程
    {
        while (true)
        {
            PoolManager.Release(objectList[Tool.GetRandomNumber(0, objectList.Length)], GetCertainBirthPosition(), Quaternion.identity);
            yield return waitForGenerateEnemyTime;
        }
    }
}
