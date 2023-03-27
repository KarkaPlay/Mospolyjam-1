using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Window : Interactable
{
    public bool questIsDone = false;
    public GameObject openCutscene;
    public GameObject exitCutscene;
    public AudioSource audioSource;
    public AudioClip breakingSound, openSound;

    private void Start()
    {
        if (openCutscene)
        {
            PlayerController.Instance.StartCutscene(openCutscene);
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!playerIsNear) return;
        if (FindObjectOfType<CutScene>()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (questIsDone)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (exitCutscene)
            {
                PlayerController.Instance.StartCutscene(exitCutscene);
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    audioSource.PlayOneShot(breakingSound);
                }
                else
                {
                    audioSource.PlayOneShot(openSound);
                }
                questIsDone = true;
            }
            else
            {
                PlayerController.Instance.ShowTip("Хорошо, я могу сбежать через него. Но, если я правильно помню, тут довольно высоковато...", 4);
            }
        }
    }

    public void CompleteQuest()
    {
        questIsDone = true;
        audioSource.PlayOneShot(openSound);
    }
}
