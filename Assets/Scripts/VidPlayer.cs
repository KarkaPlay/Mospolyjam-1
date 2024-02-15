using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName;
    VideoPlayer videoPlayer;
    public Ending endingLogic;
    
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PlayVideo();
    }

    public void PlayVideo()
    {
        if (videoPlayer)
        {
            var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }
    
    void OnDisable() //Отписываем для предотвращения утечки памяти
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer causedVideoPlayer)
    {
        Debug.Log("Видео закончилось");
        gameObject.SetActive(false);
        endingLogic.VideoEnded();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
