using System;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    public enum QuestState
    {
        NotStarted = 0, InProcess = 1, IsDone = 2
    }
    
    public QuestObject questObject;
    
    [SerializeField] private QuestState _questState = QuestState.NotStarted;

    private void Awake()
    {
        questObject.SetQuest(this);
    }

    public QuestState GetQuestState()
    {
        return _questState;
    }
    
    public void CompleteQuest()
    {
        _questState = QuestState.IsDone;
    }

    public void StartQuest()
    {
        _questState = QuestState.InProcess;
    }
}
