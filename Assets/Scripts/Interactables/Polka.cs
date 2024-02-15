using UnityEngine;

public class Polka : Interactable
{
    public GameObject cutscenePrefab1, cutscenePrefab2;
    public Sprite newSprite;
    public bool hasOtvertka = false;
    public Otvertka otvertka;
    public Window window;
    void Update()
    {
        if (!CanInteract()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hasOtvertka)
            {
                PlayerController.Instance.StartCutscene(cutscenePrefab1);
                otvertka.interactedWithPolka = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = newSprite;
                transform.position = new Vector3(-73, 0 ,0);
                PlayerController.Instance.StartCutscene(cutscenePrefab2);
                window.CompleteQuest();
            }
        }
    }
}
