using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
class Dialogue
{
    public int dialogueID;
    private int _currentLineIndex = 0;
    [SerializeField] private List<Line> _dialogueLines;
    
    [HideInInspector] public TextMeshProUGUI dialogueTextUI;
    [HideInInspector] public TextMeshProUGUI characterNameUI;

    public void StartDialogue()
    {
        Debug.Log($"Начали диалог {dialogueID}");
        _currentLineIndex = 0;
        NextLine();
    }

    public void NextLine()
    {
        if (_currentLineIndex >= _dialogueLines.Count)
        {
            EndDialogue();
            return;
        }

        var line = _dialogueLines[_currentLineIndex];
        Debug.Log($"{line.character} говорит: {line.text}");
        _currentLineIndex++;

        characterNameUI.text = line.character;
        dialogueTextUI.text = line.text;
    }

    public void EndDialogue()
    {
        Debug.Log("Диалог завершен");
    }
}
