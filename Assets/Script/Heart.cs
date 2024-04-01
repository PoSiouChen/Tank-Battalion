using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite heartDie; 
    [SerializeField] private GameObject explode;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void Die()
    {
        sr.sprite = heartDie;
        Instantiate(explode, transform.position, transform.rotation);
    }
}
