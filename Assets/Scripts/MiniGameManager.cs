using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnDefectEvent : UnityEvent<int>{}
public class MiniGameManager : MonoBehaviour
{   
    
    [SerializeField] private UnityEvent onMiniGameStart;
    [SerializeField] private UnityEvent onMiniGameEnd;
    
    [SerializeField] private OnDefectEvent onDefectEvent;
     private int _defectCount;

     public void IncrementDefectCounter()
     {
         if (_defectCount >= 5)
         {
             onMiniGameEnd?.Invoke();
             return;
         }
         _defectCount++;
         onDefectEvent?.Invoke(_defectCount);
     }
    
}
