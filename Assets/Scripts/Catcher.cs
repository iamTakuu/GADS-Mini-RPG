using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Catcher : MonoBehaviour
{
    [SerializeField] private UnityEvent onCatchBadBattery;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bad-Battery"))
        {
            onCatchBadBattery?.Invoke();   
        }
        Destroy(other.gameObject);
    }
}
