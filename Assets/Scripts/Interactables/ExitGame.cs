using System.Collections;
using UnityEngine;
using Application = UnityEngine.Device.Application;

public class ExitGame : Interactable
{
    public GameObject skrimer;
    
    void Update()
    {
        if (!playerIsNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Close());
        }
    }

    private IEnumerator Close()
    {
        skrimer.SetActive(true);
        yield return new WaitForSeconds(0.02f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
