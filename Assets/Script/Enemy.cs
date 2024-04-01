using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float moveSpace = 1f;
    [SerializeField] private float limitBulletTime = 0.2f;
    [SerializeField] private float limitDirectionTime = 3f;
    private float currentBulletTime = 0;
    private float currentDirectionTime = 0;
    private int currentDirection;
    private Vector3 bulletEuler;

    
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite[] tankSprite; //up: tnaks_274, right: tnaks_276, down: tnaks_278, left: tnaks_280
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explode;
    
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        currentDirection = Random.Range(0, 4);    
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
        if(currentDirectionTime >= limitDirectionTime)
        {
            ChangeDirection();
            Move();
        }else
        {
            currentDirectionTime = currentDirectionTime + Time.deltaTime;
            Move();
        }
    }

    private void Move()
    {
        if(currentDirection == 0)
        {
            sr.sprite = tankSprite[0];
            bulletEuler = new Vector3(0, 0, 0);
            transform.Translate(0, moveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 1)
        {
            sr.sprite = tankSprite[1];
            bulletEuler = new Vector3(0, 0, -90);
            transform.Translate(moveSpace * Time.fixedDeltaTime, 0, 0);
        }else if(currentDirection == 2){
            sr.sprite = tankSprite[2];
            bulletEuler = new Vector3(0, 0, 180);
            transform.Translate(0, -moveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 3)
        {
            sr.sprite = tankSprite[3];
            bulletEuler = new Vector3(0, 0, 90);
            transform.Translate(-moveSpace * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void ChangeDirection()
    {
        currentDirection = Random.Range(0, 4);
        currentDirectionTime = 0;
    }

    private void Attack()
    {

        Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler));
        currentBulletTime = 0;

    }

    private void Die()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
