using UnityEngine;

public class Rakovina : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.Instance.ShowTip("О, хотя бы вода есть. Правда не понимаю, почему она такая ледяная", 4f);
        }
    }
}
