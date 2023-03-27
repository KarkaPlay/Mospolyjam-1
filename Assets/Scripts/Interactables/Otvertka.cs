using UnityEngine;

public class Otvertka : Interactable
{
    public Polka polka;
    public bool interactedWithPolka = false;
    
    void Update()
    {
        if (!playerIsNear) return;
	   if (FindObjectOfType<CutScene>()) return;

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
                Destroy(gameObject);
            }
        }
    }
}
