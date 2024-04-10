using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    void Start()
    {
        //爆炸特效持續0.3秒後消失
        Destroy(gameObject, 0.3f);
    }

    void Update()
    {
        
    }
}
