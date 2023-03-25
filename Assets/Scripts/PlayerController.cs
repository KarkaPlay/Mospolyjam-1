using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    [SerializeField] private float _speed;
    private float _moveHor, _moveVer;

    private Rigidbody2D rb;
    
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
    
    private void Update()
    {
        _moveHor = Input.GetAxis("Horizontal");
        _moveVer = Input.GetAxis("Vertical");

        var movement = new Vector2(_moveHor, _moveVer);
        rb.velocity = movement * _speed;
    }
}
