using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float bornTime = 0.8f;

    [Header("Object")]
    [SerializeField] private GameObject bornObject;
    void Start()
    {
        //動畫持續bornTime後，把動畫體換成坦克
        Invoke("BornTank", bornTime);
        Destroy(gameObject, bornTime);
    }

    void Update()
    {

    }

    private void BornTank() //產生坦克
    {
        Instantiate(bornObject, transform.position, transform.rotation, transform.parent);
    }
}
