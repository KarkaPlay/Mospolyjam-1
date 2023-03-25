using System;
using UnityEngine;

public class CollectLeika : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    PlayerController.Instance.ShowTip("Хм, лейка. Интересно, чья она");
                    break;
                case NPCQuest.QuestState.InProcess:
                    PlayerController.Instance.ShowTip("Отлично, вот и она");
                    _quest.CompleteQuest();
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
