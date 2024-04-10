using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float moveSpace = 10f;
    [SerializeField] private bool isPlayerBullet = true;

    void Update()
    {
        transform.Translate(transform.up * moveSpace * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //判斷子彈打到的是什麼
        switch(collision.tag)
        {
            case "tank":
                if(!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
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
                if(isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
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
