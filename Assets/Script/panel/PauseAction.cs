using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseAction : MonoBehaviour
{
    public UnityEvent onPause;

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            onPause.Invoke();
        }
    }
}
