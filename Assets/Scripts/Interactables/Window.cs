using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Window : Interactable
{
    public bool questIsDone = false;
    public GameObject openCutscene;
    public GameObject exitCutscene;

    private void Start()
    {
        if (openCutscene)
        {
            PlayerController.Instance.StartCutscene(openCutscene);
        }
    }

    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (questIsDone)
            {
                if (SceneManager.GetActiveScene().name != "Level6")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    // Запустить финальные титры (может их на отдельную сцену, хз)
                    Application.Quit();
                }
            }
            else if (exitCutscene)
            {
                PlayerController.Instance.StartCutscene(exitCutscene);
                questIsDone = true;
            }
            else
            {
                PlayerController.Instance.ShowTip("Мне сюда пока рано", 2);
            }
        }
    }
}
