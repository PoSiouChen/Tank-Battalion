using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LostAction : MonoBehaviour
{
    public UnityEvent onPause;

    public void ActiveLostPanel()
    {
        onPause.Invoke();
    }
}


