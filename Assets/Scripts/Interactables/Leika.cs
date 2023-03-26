using System;
using UnityEngine;

public class Leika : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    PlayerController.Instance.ShowTip("Лейка. Никогда не умел ухаживать за растениями, они умирали через неделю-две", 4f);
                    break;
                case NPCQuest.QuestState.InProcess:
                    PlayerController.Instance.ShowTip("Хм... Может, мне стоит полить то щупальце?", 3f);
                    _quest.questObjects[0].GetComponent<Gorshok>().hasLeika = true;
                    Destroy(gameObject);
                    break;
                case NPCQuest.QuestState.IsDone:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}
