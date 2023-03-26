using System;
using Unity.VisualScripting;
using UnityEngine;

public class LeftCube : QuestObject
{
    private void Update()
    {
        if (!playerIsNear) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    PlayerController.Instance.ShowTip("Вы еще не взяли этот квест", 2);
                    break;
                case NPCQuest.QuestState.InProcess:
                    GetComponent<SpriteRenderer>().color = Color.cyan;
                    _quest.CompleteQuest();
                    PlayerController.Instance.ShowTip("Ну вот, ему должно понравится", 2);
                    break;
                case NPCQuest.QuestState.IsDone:
                    PlayerController.Instance.ShowTip("Теперь кубик голубой, Натан доволен)", 2);
                    break;
            }
        }
    }
}
