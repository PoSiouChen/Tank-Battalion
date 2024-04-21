using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    private Player Player;
    [Header("Object")]
    [SerializeField] private Sprite heartDie; 
    [SerializeField] private GameObject explode;
    
    void Start()
    {
        //拿到heart死掉後的圖片
        sr = GetComponent<SpriteRenderer>();

        Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        
    }

    private void Die() //heart被打到
    {
        //替換成死掉後的圖片、爆炸特效
        sr.sprite = heartDie;
        Instantiate(explode, transform.position, transform.rotation, transform);

        FindObjectOfType<Player>()?.changePlayerState();
        
    }
}
