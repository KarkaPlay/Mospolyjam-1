using UnityEngine;
using UnityEngine.SceneManagement;

public class Domik : Interactable
{
    public Rascheska rascheska;
    public GameObject cutscenePrefab1;
    public GameObject cutscenePrefab2;
    public bool interactedWithRascheska = false;
    public Sprite newWindowSprite;
    public Sprite newDomik;
    public SpriteRenderer windowSR;
    
    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level2" or "Level2_NEW":
                    Level2Behaviour();
                    break;
                default:
                    PlayerController.Instance.ShowTip("Привет, домик", 2f);
                    break;
            }
        }
    }

    private void Level2Behaviour()
    {
        if (interactedWithRascheska)
        {
            //TODO: Крупный спрайт домика, фон можно затемнить. Затем кадр домика, к окну которого приставлена расческа.
            PlayerController.Instance.StartCutscene(cutscenePrefab2);
            GetComponent<SpriteRenderer>().sprite = newDomik;
            windowSR.sprite = newWindowSprite;
        }
        else
        {
            PlayerController.Instance.StartCutscene(cutscenePrefab1);
            rascheska.interactedWithHouse = true;
        }
    }
}
