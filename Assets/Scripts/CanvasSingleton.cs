using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSingleton : MonoBehaviour
{
    public static CanvasSingleton Instance { get; private set;  }

    public GameObject levelCompleteScreen;

    void Awake()
    {
        Instance = this;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowScreen()
    {
        levelCompleteScreen.SetActive(true);
        PlayerController.Instance.StopControl();
    }
}
