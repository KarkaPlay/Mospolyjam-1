using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private List<Dialogue> _dialogues;
    private bool _dialogueIsStarted = false;
    private Dialogue _currentDialogue = null;
    
    public TextMeshProUGUI dialogueTextUI;
    public TextMeshProUGUI characterNameUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вошел в зону триггера");
            _currentDialogue = _dialogues[0];
            _currentDialogue.characterNameUI = characterNameUI;
            _currentDialogue.dialogueTextUI = dialogueTextUI;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вышел из зоны триггера");
            _currentDialogue = null;
        }
    }

    private void Update()
    {
        if (_currentDialogue != null && Input.GetKeyDown(KeyCode.E))
        {
            if (!_dialogueIsStarted)
            {
                _dialogueIsStarted = true;
                _currentDialogue.StartDialogue();
            }
            else
            {
                _currentDialogue.NextLine();
            }
        }
    }
}
