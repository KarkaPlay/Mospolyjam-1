using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    protected bool playerIsNear = false;

    protected bool CanInteract()
    {
        return (playerIsNear && PlayerController.Instance.canMove);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            PlayerController.Instance.pressEUI.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            PlayerController.Instance.pressEUI.gameObject.SetActive(false);
        }
    }
}
