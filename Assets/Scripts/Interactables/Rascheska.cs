using UnityEngine;

public class Rascheska : Interactable
{
    public bool interactedWithHouse = false;
    public Domik domik;
    
    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactedWithHouse)
            {
                PlayerController.Instance.ShowTip("...Это похоже на лестницу", 2);
                domik.interactedWithRascheska = true;
                Destroy(gameObject);
            }
            else
            {
                PlayerController.Instance.ShowTip("Гребешок. Не хочу сейчас расчесываться", 3);
            }
        }
    }
}
