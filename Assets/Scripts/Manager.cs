using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Manager : MonoBehaviour
{
    [SerializeField]private KeyCode interactKey = KeyCode.E;

    private bool _isInteracting;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (_isInteracting)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Update()
    {
        if (interactKey != KeyCode.None && Input.GetKeyDown(interactKey))
        {
           
                _isInteracting = true;
           
        }
    }
}
