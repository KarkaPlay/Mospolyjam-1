using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Gorshok : QuestObject
{
    public bool hasLeika;
    public bool leikaHasWater;

    public Sprite windowSprite;
    public GameObject cutscenePrefab;
    
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_quest.GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    // Запустится диалог
                    break;
                case NPCQuest.QuestState.InProcess:
                    if (hasLeika && leikaHasWater)
                    {
                        PlayerController.Instance.ShowTip("Поливаем...", 2f);
                        
                        // TODO: Спрайт обычного окна и горшка меняются на спрайт разбитого окна, в которое влетело выросшее щупальце.
                        _quest.CompleteQuest();
                        break;
                    }
                    if (!GetComponent<NPCDialogue>().dialogueIsStarted)
                    {
                        if (hasLeika)
                            PlayerController.Instance.ShowTip("Теперь нужно налить воды в лейку", 4f);
                        else
                            PlayerController.Instance.ShowTip("Ну щупальце, да", 2f);
                    }
                    break;
                case NPCQuest.QuestState.IsDone:
                    // Запустится диалог
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
