using System;
using UnityEngine;

public class QuestObject : Interactable
{
    [SerializeField] protected NPCQuest _quest;
    
    public void SetQuest(NPCQuest quest)
    {
        _quest = quest;
    }
}