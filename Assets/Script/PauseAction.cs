using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseAction : MonoBehaviour
{
    public UnityEvent onPause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            onPause.Invoke();
        }
    }
}
