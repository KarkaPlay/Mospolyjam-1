using UnityEngine;

public class Bed : Interactable
{
    public GameObject cutscenePrefab;
    public Sprite whiteBed;
    public Window window;

    private int interactionCount = 0;
    void Update()
    {
        if (!CanInteract()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (interactionCount)
            {
                case 0:
                    PlayerController.Instance.StartCutscene(cutscenePrefab);
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = whiteBed;
                    GetComponent<AudioSource>().Play();
                    PlayerController.Instance.ShowTip("Вот так, теперь в окно", 2f);
                    window.CompleteQuest();
                    break;
                default:
                    PlayerController.Instance.ShowTip("Наволочку взял, теперь в окно", 3f);
                    break;
            }

            interactionCount++;
        }
    }
}
