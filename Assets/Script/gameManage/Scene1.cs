using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject[] material; //0: brick, 1: grass, 2: water, 3: wall, 4: slip
    [SerializeField] private GameObject bigBrick;
    private float brickWidth = 0.32f;
    private float bigBrickWidth = 0.64f, grassWidth = 0.57f;
    private void Awake() 
    {
        creatHeart();
        creatScene();
    }

    private void creatHeart() //產生heart，跟圍住heart的牆
    {
        Instantiate(heart, new Vector3(0, -4.7f, 0), transform.rotation);

        for(float i = -4.84f; i < -4.84f + 4*brickWidth; i += brickWidth) 
        {
            Instantiate(material[0], new Vector3(-0.48f, i, 0), transform.rotation, transform); //內col 4塊
            Instantiate(material[0], new Vector3(0.48f, i, 0), transform.rotation, transform);

            Instantiate(material[0], new Vector3(-0.8f, i, 0), transform.rotation, transform); //外col 4塊
            Instantiate(material[0], new Vector3(0.8f, i, 0), transform.rotation, transform);
        }

        for(float i = -0.16f; i < -0.16f + 2*brickWidth; i += brickWidth)
        {
            Instantiate(material[0], new Vector3(i, -4.2f, 0), transform.rotation, transform); //內row 2塊
            Instantiate(material[0], new Vector3(i, -3.88f, 0), transform.rotation, transform); //外row 2塊
        }   
    }

    private void creatScene()
    {
        for(float i = -2.14f; i < -2.14f + 4*bigBrickWidth; i += bigBrickWidth)
        {
            Instantiate(bigBrick, new Vector3(-1.8f, i, 0), transform.rotation, transform);
            Instantiate(bigBrick, new Vector3(-3.1f, i, 0), transform.rotation, transform); 

            Instantiate(bigBrick, new Vector3(2.1f, i, 0), transform.rotation, transform);
            Instantiate(bigBrick, new Vector3(3.4f, i, 0), transform.rotation, transform); 
            
        }

        for(float i = 2.6f; i < 2.6f + 3*bigBrickWidth; i += bigBrickWidth)
        {
            Instantiate(bigBrick, new Vector3(-1.8f, i, 0), transform.rotation, transform);
            Instantiate(bigBrick, new Vector3(-3.1f, i, 0), transform.rotation, transform); 

            Instantiate(bigBrick, new Vector3(2.1f, i, 0), transform.rotation, transform);
            Instantiate(bigBrick, new Vector3(3.4f, i, 0), transform.rotation, transform); 
            
        }

        for(float i = -1.20f; i < -1.20f + 4*grassWidth; i += grassWidth)
        {
            Instantiate(material[1], new Vector3(-0.68f, i, 0), transform.rotation, transform); //grass
            Instantiate(material[4], new Vector3(-0.09f, i, 0), transform.rotation, transform); //slip
            Instantiate(material[4], new Vector3(0.5f, i, 0), transform.rotation, transform); //slip
        }   

        for(float i = -2.68f; i < -2.68f + 4*grassWidth; i += grassWidth)
        {
            Instantiate(material[2], new Vector3(i, 1.64f, 0), transform.rotation, transform); //water
        }
        
        
    }

}
