using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float limitBulletTime = 0.4f;
    [SerializeField] private float originalMoveSpace = 3f;
    [SerializeField] private float defendTime = 1f;
    private float currentMoveSpace;
    private float currentBulletTime = 0;
    private Vector3 bulletEuler;
    public bool isDied = false;
    private bool isDefend = true;
    

    
    private SpriteRenderer sr;

    [Header("Object")]
    [SerializeField] private Sprite[] tankSprite; //up: tnaks_0, right: tnaks_0, down: tnaks_0, left: tnaks_6
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explode;
    [SerializeField] private GameObject defend; 
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();    
        currentMoveSpace = originalMoveSpace;
    }

    void Update()
    {
        if(isDefend){
            defend.SetActive(true);
            defendTime -= Time.deltaTime;
            if(defendTime <= 0){
                isDefend = false;
                defend.SetActive(false);
            }
        }
        if (isDied)
        {
            Debug.Log("player lost");
            FindObjectOfType<LostAction>()?.ActiveLostPanel();
            
        }
        //限制每次發子彈的間隔時間
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

    private void Move() //玩家移動
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            sr.sprite = tankSprite[0];
            bulletEuler = new Vector3(0, 0, 0);
            transform.Translate(0, currentMoveSpace * Time.fixedDeltaTime, 0);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.sprite = tankSprite[1];
            bulletEuler = new Vector3(0, 0, -90);
            transform.Translate(currentMoveSpace * Time.fixedDeltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.DownArrow))
        {
            sr.sprite = tankSprite[2];
            bulletEuler = new Vector3(0, 0, 180);
            transform.Translate(0, -currentMoveSpace * Time.fixedDeltaTime, 0);
        }else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.sprite = tankSprite[3];
            bulletEuler = new Vector3(0, 0, 90);
            transform.Translate(-currentMoveSpace * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void Attack() //按空白鍵發子彈
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler), transform);
            currentBulletTime = 0;
        }
    }

    private void Die() //被敵人打到
    {
        if(isDefend){
            return;
        } else
        {
            isDied = true;
        }
        Instantiate(explode, transform.position, transform.rotation, transform);
        //Destroy(gameObject);
    }

    public void changePlayerState() //heart被打到
    {
        isDied = true;
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
}
