using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    private bool _dialogueIsStarted = false;
    
    private void Start()
    {
        //PlayerController.Instance.SetDialogueUIActive(true);
        SetDialogue();
        _dialogueIsStarted = true;
        _dialogue.StartDialogue();
    }

    private void SetDialogue()
    {
        _dialogue.characterNameUI = PlayerController.Instance.characterNameUI;
        _dialogue.dialogueTextUI = PlayerController.Instance.dialogueTextUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_dialogueIsStarted)
            {
                _dialogue.NextLine();
            }

            if (_dialogue.currentLineIsTheLast)
            {
                Destroy(gameObject);
            }
        }
    }
}
