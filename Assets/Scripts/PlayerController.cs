using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    [SerializeField] private float _speed;
    private float _moveHor, _moveVer;
    private bool canMove = true;
    private float tipFadeTime = 0.5f;
    private float tipDisplayTime = 2f;
    private Rigidbody2D _rb;

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
        
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (canMove)
        {
            _moveHor = Input.GetAxis("Horizontal");
            _moveVer = Input.GetAxis("Vertical");

            var movement = new Vector2(_moveHor, _moveVer);
            _rb.velocity = movement * _speed;
        }
    }
    
    public void SetDialogueUIActive(bool setActive)
    {
        dialoguePanel.SetActive(setActive);
        canMove = !setActive;
        if (setActive)
            _rb.velocity = Vector2.zero;
    }

    public void ShowTip(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowTipCoroutine(text));
    }

    private IEnumerator ShowTipCoroutine(string text)
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
