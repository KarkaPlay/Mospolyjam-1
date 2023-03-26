using UnityEngine;

public class Bed : Interactable
{
    public GameObject cutscenePrefab;
    public Sprite whiteBed;
    
    private bool firstTime = true;
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (firstTime)
            {
                PlayerController.Instance.StartCutscene(cutscenePrefab);
                GetComponent<SpriteRenderer>().sprite = whiteBed;
                firstTime = false;
            }

            else if (!FindObjectOfType<CutScene>())
            {
                PlayerController.Instance.ShowTip("Наволочку взял, теперь в окно", 3f);
            }
        }
    }
}
