using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
/// <summary>
/// 鼠标管理器，处理鼠标的各种时间
/// </summary>
public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] LayerMask ignoreLayer;//忽略射线层
    [SerializeField] Transform playerTransform;//玩家的transform组件
    public RaycastHit hitInfo;//射线击中对象的信息
    Ray ray;//射线
    Vector3 region;//源点
    Vector3 target;//鼠标点击目标点
    Vector3 hitDirection;//鼠标点击点的位置向量，相对玩家
    public event UnityAction<GameObject> OnMouseOver;
    public event UnityAction OnMouseExit;
    protected override void Awake()
    {
        base.Awake();
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//设置射线
        MouseControl();
    }
    public Vector3 GetMouseHitPosition()//获取鼠标点击的位置相对玩家的向量
    {
        if (Physics.Raycast(ray, out hitInfo, ignoreLayer))
        {
            region.x = playerTransform.position.x;
            region.z = playerTransform.position.z;
            target.x = hitInfo.point.x;
            target.z = hitInfo.point.z;
            hitDirection = target - region;
            return hitDirection;
        }
        return Vector3.zero;
    }
    void MouseControl()//获取鼠标点击的位置相对玩家的向量
    {
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (SceneManager.GetActiveScene().name == "ChoseLevel")
            {
                if (hitInfo.collider.tag == "LevelCube")
                {
                    OnMouseOver.Invoke(hitInfo.collider.gameObject);
                }
                else
                {
                    OnMouseExit.Invoke();
                }
            }
        }
    }
}
