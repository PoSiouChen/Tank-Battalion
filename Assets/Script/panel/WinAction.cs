using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinAction : MonoBehaviour
{
    public UnityEvent onPause;

    public void ActiveWinPanel()
    {
        onPause.Invoke();
    }
}



