using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float moveSpace = 10f;
    [SerializeField] private bool isPlayerBullet = true;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.up * moveSpace * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.tag)
        {
            case "tank":
                if(!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                }
                break;
            case "grass":
                break;
            case "water":
                break;
            case "wall":
                Destroy(gameObject);
                break;
            case "brick":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "enemy":
                break;
            case "heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "border":
                Destroy(gameObject);
                break;
        }
    }
}
