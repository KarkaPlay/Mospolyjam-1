using UnityEngine;

public class Gorshok : Interactable
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Your interaction here
        }
    }
}
