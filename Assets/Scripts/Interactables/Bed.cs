using UnityEngine;

public class Bed : Interactable
{
    public GameObject cutscenePrefab;
    public Sprite whiteBed;
    
    private int interactionCount = 0;
    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (interactionCount)
            {
                case 0:
                    PlayerController.Instance.StartCutscene(cutscenePrefab);
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = whiteBed;
                    PlayerController.Instance.ShowTip("Вот так, теперь в окно", 2f);
                    break;
                default:
                    PlayerController.Instance.ShowTip("Наволочку взял, теперь в окно", 3f);
                    break;
            }

            interactionCount++;
        }
    }
}
