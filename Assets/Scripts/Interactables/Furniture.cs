using UnityEngine;

public class Furniture : Interactable
{
    public string tipText;
    public float tipTime;
    
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.Instance.ShowTip(tipText, tipTime);
        }
    }
}
