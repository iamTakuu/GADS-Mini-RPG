using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _coolDownTime = 1f;
    [SerializeField] private float _activeTime = 0.2f;
    private bool _coolDownActive;
    
    [Space(5)]
    [Header("Movement")]
    [SerializeField] private List<Transform> lanePositions;

    enum Lane
    {
        Top, // 0
        Middle, // 1
        Bottom // 2
    }
    
    private Lane _currentLane = Lane.Middle;
   

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
    }
    
    private void MoveUp()
    {
        if (_currentLane == Lane.Top) return;
        _currentLane--;
        transform.position = new Vector3(
            transform.position.x,
            lanePositions[(int)_currentLane].position.y,
            transform.position.z);
    }
    private void MoveDown()
    {
        if (_currentLane == Lane.Bottom) return;
        _currentLane++;
        transform.position = new Vector3(
            transform.position.x,
            lanePositions[(int)_currentLane].position.y,
            transform.position.z);
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
