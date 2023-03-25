using System;
using Unity.VisualScripting;
using UnityEngine;

public class LeftCube : QuestObject
{
    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Нажата клавиша E");
            if (_quest.GetQuestState() == NPCQuest.QuestState.InProcess)
            {
                Debug.Log("Выполняется квест");
                GetComponent<SpriteRenderer>().color = Color.cyan;
                _quest.CompleteQuest();
                Debug.Log("Квест выполнен");
            }
        }
    }*/

    private void Update()
    {
        if (!playerIsNear) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    PlayerController.Instance.ShowTip("Вы еще не взяли этот квест");
                    break;
                case NPCQuest.QuestState.InProcess:
                    GetComponent<SpriteRenderer>().color = Color.cyan;
                    _quest.CompleteQuest();
                    PlayerController.Instance.ShowTip("Ну вот, ему должно понравится");
                    break;
                case NPCQuest.QuestState.IsDone:
                    PlayerController.Instance.ShowTip("Теперь кубик голубой, Натан доволен)");
                    break;
            }
        }
    }
}
