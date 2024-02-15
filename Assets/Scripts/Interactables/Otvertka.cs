using UnityEngine;

public class Otvertka : Interactable
{
    public Polka polka;
    public bool interactedWithPolka = false;
    
    void Update()
    {
        if (!CanInteract()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!interactedWithPolka)
            {
                PlayerController.Instance.ShowTip("Ее тут точно не было. Понятия не имею, что мне с ней делать", 4);
            }
            else
            {
                PlayerController.Instance.ShowTip("Отлично. То, что нужно", 2);
                polka.hasOtvertka = true;
                PlayerController.Instance.PickUpSound();
                Destroy(gameObject);
            }
        }
    }
}
