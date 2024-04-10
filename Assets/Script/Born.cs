using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float animationTime = 0.8f;

    [Header("Object")]
    [SerializeField] private GameObject player;
    void Start()
    {
        //動畫持續animationTime後，把動畫體換成坦克
        Invoke("BornTank", animationTime);
        Destroy(gameObject, animationTime);
    }

    void Update()
    {

    }

    private void BornTank() //產生坦克
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
