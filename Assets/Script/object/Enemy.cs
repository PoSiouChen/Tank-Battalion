using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float originalMoveSpace = 1f;
    [SerializeField] private float limitBulletTime = 0.2f;
    [SerializeField] private float limitDirectionTime = 1f;
    private float currentMoveSpace;
    private float currentBulletTime = 0;
    private float currentDirectionTime = 0;
    private int currentDirection; //0:up, 1:right, 2:down, 3:left
    private Vector3 bulletEuler;
    private CreateEnemy createEnemy;
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite[] tankSprite; //up: tnaks_274, right: tnaks_276, down: tnaks_278, left: tnaks_280
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explode;

    private Transform player;
    private Transform enemy;
    private float playerX, playerY; 
    private float enemyX, enemyY; 

    
    private void Awake() {
        //拿到4個方向坦克的圖片
        sr = GetComponent<SpriteRenderer>();

        currentMoveSpace = originalMoveSpace;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Transform>();
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
            if (Random.Range(0, 2) == 0)
            {
                trackPlayerX();
            } else
            {
                trackPlayerY();
            }
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
            transform.Translate(0, currentMoveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 1)
        {
            sr.sprite = tankSprite[1]; //1:right
            bulletEuler = new Vector3(0, 0, -90);
            transform.Translate(currentMoveSpace * Time.fixedDeltaTime, 0, 0);
        }else if(currentDirection == 2) //2:down
        {
            sr.sprite = tankSprite[2];
            bulletEuler = new Vector3(0, 0, 180);
            transform.Translate(0, -currentMoveSpace * Time.fixedDeltaTime, 0);
        }else if(currentDirection == 3) //3:left
        {
            sr.sprite = tankSprite[3];
            bulletEuler = new Vector3(0, 0, 90);
            transform.Translate(-currentMoveSpace * Time.fixedDeltaTime, 0, 0);
        }
    }

    /*
    private void ChangeDirection() //每隔一段時間自動換方向
    {
        currentDirection = Random.Range(0, 4);
        currentDirectionTime = 0;
    }
    */
    private void Attack() //攻擊，依目前坦克的方向發子彈
    {

        Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler), transform);
        currentBulletTime = 0;

    }

    private void Die() //被玩家打到，消失
    {
        //Debug.Log("enemy die");
        Instantiate(explode, transform.position, transform.rotation, transform);
        Destroy(gameObject);
        
        //生一個新的敵人
        updateEnemyNumber();
    }

    private void updateEnemyNumber()
    {
        //Debug.Log("new enemy");
        FindObjectOfType<CreateEnemy>()?.updateEnemyNumber();
    }

        private void OnTriggerEnter2D(Collider2D collision) //進入打滑的地板
    {
        if(collision.tag == "slip")
        {
            currentMoveSpace = originalMoveSpace * 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //離開打滑的地板
    {
        if(collision.tag == "slip")
        {
            currentMoveSpace = originalMoveSpace;
        }
    }

    private void trackPlayerX()
    {
        playerX = player.position.x;
        enemyX = enemy.position.x;

        if(playerX > enemyX)
        {
            currentDirection = 1;
        } else
        {
            currentDirection = 3;
        }
        currentDirectionTime = 0;
    }

    private void trackPlayerY()
    {
        playerY = player.position.y;
        enemyY = enemy.position.y;

        if(playerY > enemyY)
        {
            currentDirection = 0;
        } else
        {
            currentDirection = 2;
        }
        currentDirectionTime = 0;
    }
}
