using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private int numberOfEnemy = 20;  
    private int currentEnemy;
    private float[] xPositionRange = new float[] {-3.9f, 3.9f}; 
    private float yPositionRange = 3.2f;
    private float xPosition, yPosition;

    void Start()
    {
        currentEnemy = numberOfEnemy;
    }

    public void updateEnemyNumber()
    {
        currentEnemy -= 1;
        if(currentEnemy > 0)
        {
            newEnemy();
        }else
        {
            Debug.Log("player win");
            FindObjectOfType<WinAction>()?.ActiveWinPanel();
        }
        Debug.Log(currentEnemy);
    }
    private void newEnemy() //隨機位置產生新敵人
    {
        xPosition = Random.Range(xPositionRange[0], xPositionRange[1]);
        yPosition = yPositionRange;
        Instantiate(enemy, new Vector3(xPosition, yPosition), transform.rotation, transform);
    }
}
