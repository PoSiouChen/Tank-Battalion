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
        Invoke("BornTank", animationTime);
        Destroy(gameObject, animationTime);
    }

    void Update()
    {

    }

    private void BornTank()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
