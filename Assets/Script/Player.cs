using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float moveSpace = 4f;
    [SerializeField] private float limitBulletTime = 0.2f;
    private float currentBulletTime = 0;
    private Vector3 bulletEuler;

    
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite[] tankSprite; //up: tnaks_0, right: tnaks_0, down: tnaks_0, left: tnaks_6
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explode;
    
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();    
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(currentBulletTime >= limitBulletTime)
        {
            Attack();
        }else
        {
            currentBulletTime = currentBulletTime + Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            sr.sprite = tankSprite[0];
            bulletEuler = new Vector3(0, 0, 0);
            transform.Translate(0, moveSpace * Time.fixedDeltaTime, 0);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.sprite = tankSprite[1];
            bulletEuler = new Vector3(0, 0, -90);
            transform.Translate(moveSpace * Time.fixedDeltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.DownArrow)){
            sr.sprite = tankSprite[2];
            bulletEuler = new Vector3(0, 0, 180);
            transform.Translate(0, -moveSpace * Time.fixedDeltaTime, 0);
        }else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.sprite = tankSprite[3];
            bulletEuler = new Vector3(0, 0, 90);
            transform.Translate(-moveSpace * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void Attack()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler));
            currentBulletTime = 0;
        }
    }

    private void Die()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
