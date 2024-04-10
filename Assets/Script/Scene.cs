using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Scene : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private int brickNumber = 50;
    [SerializeField] private int wallNumber = 20;
    [SerializeField] private int grassNumber = 1;

    [Header("Object")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject[] material;

    private List<(float, float)> allPosition = new List<(float, float)>(); 


    private void Awake() {
        for(float i = -4.84f; i <= 4.84f; i += 0.32f)
        {
            for(float j = -4.84f; j <= 4.84f; j += 0.32f)
            {
                allPosition.Add((i, j));
                if(j >= -4.84f && j < -3.88f && i >= -0.5f && i <= 0.5f)
                {
                    allPosition.Remove((i, j));
                }
            }
        }
        creatHeart();
        creatScene();
    }

    private void creatHeart(){
        Instantiate(heart, new Vector3(0, -4.7f, 0), transform.rotation);
        //randomMaterial = Random.Range(0, 3);
        for(float i = -4.84f; i < -3.88f; i += 0.32f)
        {
            Instantiate(material[0], new Vector3(-0.48f, i, 0), transform.rotation);
            Instantiate(material[0], new Vector3(0.48f, i, 0), transform.rotation);
        }
        for(float i = -0.16f; i < 0.48f; i += 0.32f)
            Instantiate(material[0], new Vector3(i, -4.2f, 0), transform.rotation);
    }
    private void creatScene(){
        for(int i = 0; i < brickNumber; i++)
        {
            var position = allPosition[Random.Range(0, allPosition.Count)];
            Instantiate(material[0], new Vector3(position.Item1, position.Item2, 0), transform.rotation);
            allPosition.Remove(position);
        }
        for(int i = 0; i < wallNumber; i++)
        {
            var position = allPosition[Random.Range(0, allPosition.Count)];
            Instantiate(material[1], new Vector3(position.Item1, position.Item2, 0), transform.rotation);
            allPosition.Remove(position);
        }
        // for(int i = 0; i < grassNumber; i++){
        //     var position = allPosition[Random.Range(0, allPosition.Count)];
        //     Instantiate(material[2], new Vector3(position.Item1, position.Item2, 0), transform.rotation);
        //     allPosition.Remove(position);
        // }
        
    }
}
