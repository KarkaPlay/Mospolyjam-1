using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Window : Interactable
{
    public bool questIsDone = false;
    public GameObject openCutscene;

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
            else
            {
                PlayerController.Instance.ShowTip("Мне сюда пока рано", 2);
            }
        }
    }
}
