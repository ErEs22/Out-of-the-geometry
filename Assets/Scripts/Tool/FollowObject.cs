using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform followObject;
    float x;
    float y;
    private void OnEnable()
    {
        StartCoroutine(nameof(FollowMoveCoroutine));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(FollowMoveCoroutine));
    }
    IEnumerator FollowMoveCoroutine()
    {
        while (true)
        {
            x = followObject.position.x;
            y = followObject.position.y;
            transform.position = new Vector3(x, y, -10f);
            yield return null;
        }
    }
}
