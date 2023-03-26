using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Gorshok : QuestObject
{
    public bool hasLeika;
    public bool leikaHasWater;

    public Sprite windowSprite;
    public Window window;

    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    Level1Behaviour();
                    break;
                case "Level3":
                    Level3Behaviour();
                    break;
            }
        }
    }

    private void Level1Behaviour()
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
                    window.gameObject.GetComponent<SpriteRenderer>().sprite = windowSprite;
                    window.questIsDone = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    /*foreach (var coll in GetComponents<Collider2D>())
                    {
                        coll.enabled = false;
                    }*/
                    _quest.CompleteQuest();
                    //Destroy(gameObject);
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

    private void Level3Behaviour()
    {
        PlayerController.Instance.ShowTip("Опять это щупальце", 2f);
    }
}
