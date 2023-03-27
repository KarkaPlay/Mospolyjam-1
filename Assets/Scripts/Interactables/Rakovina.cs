using System;
using UnityEngine;

public class Rakovina : QuestObject
{
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    PlayerController.Instance.ShowTip("О, хотя бы вода есть. Правда не понимаю, почему она такая ледяная", 4f);
                    break;
                case NPCQuest.QuestState.InProcess:
                    if (_quest.questObjects[0].GetComponent<Gorshok>().hasLeika)
                    {
                        PlayerController.Instance.ShowTip("Наливаем...", 2);
                        _quest.questObjects[0].GetComponent<Gorshok>().leikaHasWater = true;
                        GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        PlayerController.Instance.ShowTip("О, хотя бы вода есть. Правда не понимаю, почему она такая ледяная", 4f);
                    }
                    break;
                case NPCQuest.QuestState.IsDone:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
