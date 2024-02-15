using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject ratePanel;
    
    void Start()
    {
        Progress.Instance.SetNewLevel(Progress.SceneNumberByName[SceneManager.GetActiveScene().name]);
    }

    public void VideoEnded()
    {
        ratePanel.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
