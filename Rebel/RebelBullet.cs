using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RebelBullet : MonoBehaviour
{
  public float moveSpeed = 10f;
  public int damageAmount = 2;
  public float  destroyTime = 1f;
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }


    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        Destroy(gameObject);
    }
}
