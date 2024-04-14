using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelBombExplode : MonoBehaviour
{
   public float destroyByTime =1f;

    void Start()
    {
        Destroy(gameObject,destroyByTime);
    }
}
