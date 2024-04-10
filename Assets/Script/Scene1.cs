using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject[] material;
    //private List<(float, float)> allPosition = new List<(float, float)>();
    private float brickWidth = 0.32f;
    private void Awake() {

        creatHeart();
        creatScene();
    }

    private void creatHeart(){
        Instantiate(heart, new Vector3(0, -4.7f, 0), transform.rotation);

        for(float i = -4.84f; i < -4.84f + 4*brickWidth; i += brickWidth) 
        {
            Instantiate(material[0], new Vector3(-0.48f, i, 0), transform.rotation); //內col 4塊
            Instantiate(material[0], new Vector3(0.48f, i, 0), transform.rotation);

            Instantiate(material[0], new Vector3(-0.8f, i, 0), transform.rotation); //外col 4塊
            Instantiate(material[0], new Vector3(0.8f, i, 0), transform.rotation);
        }

        for(float i = -0.16f; i < -0.16f + 2*brickWidth; i += brickWidth){
            Instantiate(material[0], new Vector3(i, -4.2f, 0), transform.rotation); //內row 2塊
            Instantiate(material[0], new Vector3(i, -3.88f, 0), transform.rotation); //外row 2塊
        }   
    }

    private void creatScene(){
        
        
    }

}
