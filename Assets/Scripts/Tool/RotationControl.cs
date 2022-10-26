using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotationControl : MonoBehaviour
{
    [SerializeField] string target;
    private void OnEnable()
    {
        StartCoroutine(nameof(StableTransfrom));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(StableTransfrom));
    }
    IEnumerator StableTransfrom()
    {
        while (true)
        {
            if(GameObject.Find(target) != null)
            {
                transform.position = GameObject.Find(target).transform.position;
                transform.rotation = Quaternion.identity;
            }
            yield return null;
        }
    }
}
