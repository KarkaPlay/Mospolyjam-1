using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Ending : MonoBehaviour
{
    public GameObject ratePanel;
    
    void Start()
    {
        Progress.Instance.SetNewLevel(Progress.SceneNumberByName[SceneManager.GetActiveScene().name]);
    }

    public void VideoEnded()
    {
        if (YandexGame.EnvironmentData.reviewCanShow)
        {
            ratePanel.SetActive(true);
        }
        else
        {
            GoToMenu();
        }
    }

    public void OpenRatePanel()
    {
        YandexGame.ReviewShow(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
