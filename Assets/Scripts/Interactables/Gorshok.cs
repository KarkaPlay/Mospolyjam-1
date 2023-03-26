using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Gorshok : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
}
