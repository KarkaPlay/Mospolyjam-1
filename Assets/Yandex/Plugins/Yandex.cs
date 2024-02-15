using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetYandexPlayerData();
    
    [DllImport("__Internal")]
    private static extern void AskYandexForRate();

    [SerializeField] public TextMeshProUGUI nameText;
    [SerializeField] public RawImage photo;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
#if UNITY_WEBGL
            //GetYandexPlayerData();
#endif
        }
    }

    public void RateGameButton()
    {
#if UNITY_WEBGL
        AskYandexForRate();
#endif
    }

    public void GameRated()
    {
        SceneManager.LoadScene(0);
    }

    public void SetNameText(string name)
    {
        nameText.text = name;
        nameText.gameObject.SetActive(true);
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
        photo.gameObject.SetActive(true);
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
#if UNITY_WEBGL
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
#endif
    }
}
