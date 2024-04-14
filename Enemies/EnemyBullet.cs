using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
     private Rigidbody2D rb;
    public float speed = 10f;
    public int damage = 1;
    public float destroyByTime = 1f;
    void Start()
    {
        Destroy(gameObject,destroyByTime);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
private void OnTriggerEnter2D(Collider2D other)
    {
       

        Destroy(gameObject);
    }
}
