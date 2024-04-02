using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Scene : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject[] material;
    private int randomMaterial;

    private void Awake() {
        creatHeart();
        //creatScene();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    private void creatHeart(){
        Instantiate(heart, new Vector3(0, -4.5f, 0), transform.rotation);
        //randomMaterial = Random.Range(0, 3);
        for(float i = -4.75f; i <= -4f; i += 0.25f)
        {
            Instantiate(material[0], new Vector3(-0.5f, i, 0), transform.rotation);
            Instantiate(material[0], new Vector3(0.5f, i, 0), transform.rotation);
        }
        for(float i = -0.25f; i <= 0.25f; i += 0.25f)
            Instantiate(material[0], new Vector3(i, -4, 0), transform.rotation);
    }
    private void creatScene(){
        
        //Instantiate(material, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuler));
    }
}
