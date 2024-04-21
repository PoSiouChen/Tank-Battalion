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
    private CreateEnemy createEnemy;
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite[] tankSprite; //up: tnaks_274, right: tnaks_276, down: tnaks_278, left: tnaks_280
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explode;
    
    private void Awake() {
        //拿到4個方向坦克的圖片
        sr = GetComponent<SpriteRenderer>();

        //createEnemy = FindObjectOfType<CreateEnemy>();

        //隨機生出場時坦克的方向
        currentDirection = Random.Range(0, 4); //0:up, 1:right, 2:down, 3:left
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
        if(currentDirection == 0) //0:up
        {
            sr.sprite = tankSprite[0];
            bulletEuler = new Vector3(0, 0, 0);
            transform.Translate(0, moveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 1)
        {
            sr.sprite = tankSprite[1]; //1:right
            bulletEuler = new Vector3(0, 0, -90);
            transform.Translate(moveSpace * Time.fixedDeltaTime, 0, 0);
        }else if(currentDirection == 2) //2:down
        {
            sr.sprite = tankSprite[2];
            bulletEuler = new Vector3(0, 0, 180);
            transform.Translate(0, -moveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 3) //3:left
        {
            sr.sprite = tankSprite[3];
            bulletEuler = new Vector3(0, 0, 90);
            transform.Translate(-moveSpace * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void ChangeDirection() //每隔一段時間自動換方向
    {
        currentDirection = Random.Range(0, 4);
        currentDirectionTime = 0;
    }

    private void Attack() //攻擊，依目前坦克的方向發子彈
    {

        Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler), transform);
        currentBulletTime = 0;

    }

    private void Die() //被玩家打到，消失
    {
        Debug.Log("enemy die");
        Instantiate(explode, transform.position, transform.rotation, transform);
        Destroy(gameObject);
        
        //生一個新的敵人
        updateEnemyNumber();
    }

    private void updateEnemyNumber()
    {
        //Debug.Log("yes");
        FindObjectOfType<CreateEnemy>()?.updateEnemyNumber();
    }
}
