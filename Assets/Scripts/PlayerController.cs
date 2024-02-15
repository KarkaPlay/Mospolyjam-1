using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    

    [HideInInspector] public bool canMove = true;
    private float tipFadeTime = 0.5f;
    public float moveSpeed = 5f;
    public AudioSource audioSource;
    public AudioSource pickupAudioSource;
    public AudioClip walkSound;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    
    public GameObject cutscenePrefab;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueTextUI;
    public TextMeshProUGUI characterNameUI;
    public TextMeshProUGUI pressEUI;
    public TextMeshProUGUI tipUI;
    
    private void Awake()
    {
        Instance = this;
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        
        dialoguePanel = CanvasSingleton.Instance.gameObject.transform.GetChild(0).gameObject;
        characterNameUI = dialoguePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dialogueTextUI = characterNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        pressEUI = CanvasSingleton.Instance.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tipUI = CanvasSingleton.Instance.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        if (cutscenePrefab)
        {
            StartCutscene(cutscenePrefab);
        }
        
        Progress.Instance.SetNewLevel(Progress.SceneNumberByName[SceneManager.GetActiveScene().name]);
    }

    private void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            
            if (movement.sqrMagnitude > 0.01f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = walkSound;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        // TODO: Удалить
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void PickUpSound()
    {
        pickupAudioSource.Play();
    }

    public void StopSounds()
    {
        foreach (var audioSource in GetComponents<AudioSource>())
        {
            audioSource.Pause();
        }
    }

    public void ContinueSounds()
    {
        foreach (var audioSource in GetComponents<AudioSource>())
        {
            audioSource.UnPause();
        }
    }

    public void SetDialogueUIActive(bool setActive)
    {
        if (dialoguePanel)
            dialoguePanel.SetActive(setActive);
        
        canMove = !setActive;
        if (setActive)
            rb.velocity = Vector2.zero;
    }

    public void StartCutscene(GameObject _cutscenePrefab)
    {
        Instantiate(_cutscenePrefab);
        cutscenePrefab = null;
    }

    public void ShowTip(string text, float tipDisplayTime)
    {
        StopAllCoroutines();
        StartCoroutine(ShowTipCoroutine(text, tipDisplayTime));
    }

    private IEnumerator ShowTipCoroutine(string text, float tipDisplayTime)
    {
        tipUI.text = text;
        tipUI.color = new Color(tipUI.color.r, tipUI.color.g, tipUI.color.b, 0f);
        tipUI.gameObject.SetActive(true);
        
        // Fade in
        float timer = 0f;
        while (timer < tipFadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / tipFadeTime);
            tipUI.color = new Color(tipUI.color.r, tipUI.color.g, tipUI.color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        tipUI.color = new Color(tipUI.color.r, tipUI.color.g, tipUI.color.b, 1f);

        // Display
        yield return new WaitForSeconds(tipDisplayTime);

        // Fade out
        timer = 0f;
        while (timer < tipFadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / tipFadeTime);
            tipUI.color = new Color(tipUI.color.r, tipUI.color.g, tipUI.color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        tipUI.color = new Color(tipUI.color.r, tipUI.color.g, tipUI.color.b, 0f);
        tipUI.gameObject.SetActive(false);
    }
}
