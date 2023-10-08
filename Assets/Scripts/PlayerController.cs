using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _coolDownTime = 1f;
    [SerializeField] private float _activeTime = 0.2f;
    private bool _coolDownActive;

    private void Awake()
    {
        _collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_coolDownActive)
        {
            StartCoroutine(AttackCoolDown());
        }
    }
    
    private IEnumerator AttackCoolDown()
    {
        _collider.enabled = true;
        yield return new WaitForSeconds(_activeTime);
        _collider.enabled = false;
        _coolDownActive = true;
        yield return new WaitForSeconds(_coolDownTime);
        _coolDownActive = false;
    }
}
