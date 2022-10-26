using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class BackgroundMove : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Vector2 scrollSpeed;
    Vector2 offset;
    private void Awake()
    {
        material.SetVector("Vector2_65418bcd1d564bba8b5601b010af58a1", Vector3.zero);
    }
    private void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        material.SetVector("Vector2_65418bcd1d564bba8b5601b010af58a1", offset);
    }
}
