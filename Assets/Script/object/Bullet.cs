using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float moveSpace = 10f;
    [SerializeField] private bool isPlayerBullet = true;

    [Header("Object")]
    [SerializeField] private GameObject explode;

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
                    Instantiate(explode, transform.position, transform.rotation, transform);
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Player":
                if(!isPlayerBullet)
                {
                    Instantiate(explode, transform.position, transform.rotation, transform);
                    collision.SendMessage("Die"); 
                    Destroy(gameObject);
                }
                break;
            case "grass":
                break;
            case "water":
                break;
            case "wall":
                Instantiate(explode, transform.position, transform.rotation, transform);
                Destroy(gameObject, 0.01f);
                break;
            case "brick":
                Instantiate(explode, transform.position, transform.rotation, transform);
                Destroy(collision.gameObject);
                Destroy(gameObject, 0.01f);
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
                Destroy(gameObject, 0.01f);
                break;
            case "border":
                Instantiate(explode, transform.position, transform.rotation, transform);
                Destroy(gameObject, 0.01f);
                break;
        }
    }
}
