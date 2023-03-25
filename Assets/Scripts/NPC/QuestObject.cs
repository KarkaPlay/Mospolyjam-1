using System;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    [SerializeField] protected NPCQuest _quest;
    protected bool playerIsNear = false;

    public void SetQuest(NPCQuest quest)
    {
        _quest = quest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вошел в зону триггера квестового объекта");
            playerIsNear = true;
            PlayerController.Instance.pressEUI.gameObject.SetActive(true);
            Debug.Log("Нажмите E, чтобы выполнить квест");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вышел из зоны триггера квестового объекта");
            playerIsNear = false;
            PlayerController.Instance.pressEUI.gameObject.SetActive(false);
            Debug.Log("Подсказка не активна");
        }
    }
}
