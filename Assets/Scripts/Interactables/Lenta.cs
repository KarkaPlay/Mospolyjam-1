using UnityEngine;

public class Lenta : Interactable
{
    public GameObject cutscenePrefab;
    public Window window;
    
    private bool firstTime = true;
    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (firstTime)
            {
                PlayerController.Instance.StartCutscene(cutscenePrefab);
                firstTime = false;
            }
            else
            {
                window.questIsDone = true;
                Destroy(gameObject);
            }
        }
    }
}
