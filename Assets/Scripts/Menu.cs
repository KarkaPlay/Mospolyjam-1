using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public List<Button> levelButtons;
    public TextMeshProUGUI progressText;
    
    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(Progress.SceneNameByNumber[level]);
    }

    public void CheckProgress()
    {
        for (int i = 0; i < Progress.Instance.playerInfo.currentLevel; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
}
