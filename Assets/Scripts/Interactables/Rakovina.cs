using UnityEngine;

public class Rakovina : Interactable
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
