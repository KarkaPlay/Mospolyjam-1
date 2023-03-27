using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField] private int _currentLineIndex = 0;
    [SerializeField] private List<Line> _dialogueLines;
    public bool currentLineIsTheLast = false;

    public bool isStartQuestDialogue = false;

    [HideInInspector] public TextMeshProUGUI dialogueTextUI;
    [HideInInspector] public TextMeshProUGUI characterNameUI;

    public void StartDialogue()
    {
        PlayerController.Instance.SetDialogueUIActive(true);
        PlayerController.Instance.pressEUI.gameObject.SetActive(false);
        _currentLineIndex = 0;
        currentLineIsTheLast = false;
        NextLine();
    }
    
    public void NextLine()
    {
        if (_currentLineIndex >= _dialogueLines.Count)
        {
            currentLineIsTheLast = true;
            EndDialogue();
            return;
        }
        
        var line = _dialogueLines[_currentLineIndex];
        _currentLineIndex++;
        
        characterNameUI.text = line.character.ToString();
        dialogueTextUI.text = line.text;
    }

    public void EndDialogue()
    {
        _currentLineIndex = 0;
        PlayerController.Instance.SetDialogueUIActive(false);
    }
}
