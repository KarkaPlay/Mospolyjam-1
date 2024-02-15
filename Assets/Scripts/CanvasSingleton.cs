using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleton : MonoBehaviour
{
    public static CanvasSingleton Instance { get; private set;  }

    void Awake()
    {
        Instance = this;
    }
}
