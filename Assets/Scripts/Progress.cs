using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

[System.Serializable]
public class PlayerInfo
{
    public int currentLevel;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;
    
    public static Progress Instance;
    public static readonly Dictionary<string, int> SceneNumberByName = new()
    {
        { "Menu", 0 },
        { "Level1", 1 },
        { "Level2_NEW", 2 },
        { "Level3", 3 },
        { "Level4", 4 },
        { "Level5", 5 },
        { "Ending", 6 }
    };
    
    public static readonly Dictionary<int, string> SceneNameByNumber = new()
    {
        { 0, "Menu" },
        { 1, "Level1" },
        { 2, "Level2_NEW" },
        { 3, "Level3" },
        { 4, "Level4" },
        { 5, "Level5" },
        { 6, "Ending" }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
#if UNITY_WEBGL
        if (YandexGame.SDKEnabled)
        {
            playerInfo.currentLevel = YandexGame.savesData.currentLevel;
            StopCoroutine(CompletingLevel());
        }
#endif
    }

    public void CompleteLevel()
    {
        StartCoroutine(CompletingLevel());
        
        SetNewLevel(SceneNumberByName[SceneManager.GetActiveScene().name] + 1);
    }

    IEnumerator CompletingLevel()
    {
        CanvasSingleton.Instance.ShowScreen();
        
        yield return new WaitForSeconds(0.5f);

        if (SceneManager.GetActiveScene().buildIndex is 1 or 3)
        {
            YandexGame.FullscreenShow();
        }
    }

    public void SetNewLevel(int newLevel)
    {
        if (newLevel > playerInfo.currentLevel)
        {
            playerInfo.currentLevel = newLevel;
        }

        Save();
    }

    public void Save()
    {
#if UNITY_WEBGL
        YandexGame.savesData.currentLevel = playerInfo.currentLevel;
        YandexGame.SaveProgress();
#endif
    }
}
