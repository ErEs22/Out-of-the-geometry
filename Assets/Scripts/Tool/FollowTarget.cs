using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class FollowTarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool position;
    [SerializeField] bool rotation;
    [SerializeField] bool scale;
    Vector3 newPos;
    private void Update()
    {
        if (position)
        {
            newPos.x = target.transform.position.x;
            newPos.z = target.transform.position.z;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
        if (rotation)
        {
            transform.rotation = target.transform.rotation;
        }
        if (scale)
        {
            transform.localScale = target.transform.localScale;
        }
    }
}
