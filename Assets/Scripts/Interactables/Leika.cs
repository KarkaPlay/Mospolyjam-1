using UnityEngine;

public class Leika : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.Instance.ShowTip("Лейка. Никогда не умел ухаживать за растениями, они умирали через неделю-две", 4f);
        }
    }
}
