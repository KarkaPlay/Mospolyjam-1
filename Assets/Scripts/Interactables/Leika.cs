using UnityEngine;

public class Leika : Interactable
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
