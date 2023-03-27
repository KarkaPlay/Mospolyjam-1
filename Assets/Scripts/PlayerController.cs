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
    

    private bool canMove = true;
    private float tipFadeTime = 0.5f;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    public List<GameObject> allCutscenePrefabs;
    [FormerlySerializedAs("cutScenePrefab")] public GameObject cutscenePrefab;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueTextUI;
    public TextMeshProUGUI characterNameUI;
    public TextMeshProUGUI pressEUI;
    public TextMeshProUGUI tipUI;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
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
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = new Vector3(-50, 12, 0);
        switch(scene.name)
        {
            case "Level1":
                StartCutscene(allCutscenePrefabs[0]);
                break;
            case "Level2" or "Level2_NEW":
                StartCutscene(allCutscenePrefabs[1]);
                break;
            case "Level3":
                StartCutscene(allCutscenePrefabs[2]);
                break;
            case "Level4":
                StartCutscene(allCutscenePrefabs[3]);
                break;
            case "Level5":
                StartCutscene(allCutscenePrefabs[4]);
                break;
            case "Ending":
                break;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetDialogueUIActive(bool setActive)
    {
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
