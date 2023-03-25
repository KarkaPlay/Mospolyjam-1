using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private List<Dialogue> _dialogues;
    [SerializeField] private Dialogue _currentDialogue;
    private readonly Dialogue _nullDialogue = new Dialogue();
    private bool _dialogueIsStarted = false;
    
    private void Start()
    {
        // Можно просто выключать панель перед началом игры, тогда этот код не понадобится
        PlayerController.Instance.SetDialogueUIActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вошел в зону триггера");

            // Так можно задать нестандартные варианты диалогов, в зависимости от других условий
            /*switch (GetComponent<NPCQuest>().GetQuestState())
            {
                case NPCQuest.QuestState.NotStarted:
                    SetCurrentDialogue(0);
                    break;
                case NPCQuest.QuestState.InProcess:
                    SetCurrentDialogue(1);
                    break;
                case NPCQuest.QuestState.IsDone:
                    SetCurrentDialogue(2);
                    break;
            }*/

            PlayerController.Instance.pressEUI.gameObject.SetActive(true);
            SetCurrentDialogue((int)GetComponent<NPCQuest>().GetQuestState());
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вышел из зоны триггера");
            PlayerController.Instance.pressEUI.gameObject.SetActive(false);
            _currentDialogue.EndDialogue();
            _currentDialogue = _nullDialogue;
            _dialogueIsStarted = false;
            PlayerController.Instance.SetDialogueUIActive(false);
        }
    }

    public void SetCurrentDialogue(int index)
    {
        _currentDialogue = _dialogues[index];
        _currentDialogue.characterNameUI = PlayerController.Instance.characterNameUI;
        _currentDialogue.dialogueTextUI = PlayerController.Instance.dialogueTextUI;
    }
    
    private void Update()
    {
        if (_currentDialogue != _nullDialogue && Input.GetKeyDown(KeyCode.E))
        {
            if (_dialogueIsStarted)
            {
                _currentDialogue.NextLine();
            }
            else
            {
                _dialogueIsStarted = true;
                _currentDialogue.StartDialogue();
                
                if (_currentDialogue.isStartQuestDialogue)
                    GetComponent<NPCQuest>().StartQuest();
            }
        }
    }
}
