using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int currentLevel;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public bool isAuthorized;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    
    [DllImport("__Internal")]
    public static extern void ShowAdv();
    
    public static Progress Instance;
    public static readonly Dictionary<string, int> SceneNumberByName = new Dictionary<string, int>
    {
        { "Menu", 0 },
        { "Level1", 1 },
        { "Level2_NEW", 2 },
        { "Level3", 3 },
        { "Level4", 4 },
        { "Level5", 5 },
        { "Ending", 6 }
    };
    
    public static readonly Dictionary<int, string> SceneNameByNumber = new Dictionary<int, string>
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
        /*if (isAuthorized)
        {
            Debug.Log("isAuthorized=true, вызываем LoadExtern");
            LoadExtern();
        }
        else
        {
            Debug.Log("isAuthorized=false, вызываем SetOfflinePlayerInfo");
            SetOfflinePlayerInfo();
        }*/
        
        if (isAuthorized)
        {
            Debug.Log("isAuthorized=true, вызываем LoadExtern");
            LoadExtern();
        }
        
        ShowAdv();
#endif
    }

    public void SetNewLevel(int newLevel)
    {
        if (newLevel > playerInfo.currentLevel)
        {
            playerInfo.currentLevel = newLevel;
        }

        if (isAuthorized)
            Save();
        else
            SaveOffline();

        if (newLevel is 2 or 4)
        {
            ShowAdv();
        }
    }

    public void Save()
    {
#if UNITY_WEBGL
        Debug.Log("Сохраняем в облаке...");
        string jsonString = JsonUtility.ToJson(playerInfo);
        SaveExtern(jsonString);
        Debug.Log("Сохранили в облаке!");
#endif
    }

    public void SaveOffline()
    {
        Debug.Log("Сохраняем локально...");
        PlayerPrefs.SetInt("currentLevel", playerInfo.currentLevel);
        PlayerPrefs.Save();
        Debug.Log("Сохранили PlayerPrefs");
        Debug.Log("PlayerPrefs запомнил уровень: " + PlayerPrefs.HasKey("currentLevel"));
        Debug.Log("Он равен " + PlayerPrefs.GetInt("currentLevel"));
        Debug.Log("Сохранили локально!");
    }

    public void SetPlayerInfo(string value)
    {
#if UNITY_WEBGL
        Debug.Log("Вызван Progress.cs: SetPlayerInfo");
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
#endif
    }

    public void SetOfflinePlayerInfo()
    {
        Debug.Log("Вызван Progress.cs: SetOfflinePlayerInfo");
        
        playerInfo.currentLevel = PlayerPrefs.GetInt("currentLevel");
        
        Debug.Log("Загрузили PlayerPrefs");
        Debug.Log("PlayerPrefs вспомнил уровень: " + PlayerPrefs.HasKey("currentLevel"));
        Debug.Log("Он равен " + PlayerPrefs.GetInt("currentLevel"));
    }

    public void SetAuthorized(int authorized)
    {
        isAuthorized = authorized == 1;
        
        Debug.Log("Запустился SetAuthorized со значением "+authorized);

        if (!isAuthorized)
        {
            Debug.Log("isAuthorized=false, вызываем SetOfflinePlayerInfo");
            SetOfflinePlayerInfo();
        }
    }
}
