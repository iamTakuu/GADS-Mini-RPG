using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnDefectEvent : UnityEvent<int>{}
[Serializable]
public class OnTimeEvent : UnityEvent<float>{}
public class MiniGameManager : MonoBehaviour
{   
    [SerializeField] private float gameDuration = 30f;
    [Space(10)][Header("Events")]
    [SerializeField] private UnityEvent onMiniGameStart;
    [SerializeField] private UnityEvent onMiniGameEnd;
    [SerializeField] private OnDefectEvent onDefectEvent;
    
    [SerializeField] private OnTimeEvent onTimeEvent;
     private int _defectCount;

     bool _isGameActive = true;
     private void Start()
     {
         onMiniGameStart?.Invoke();
     }

     
     public void TrackGameTime()
     {
         gameDuration -= Time.deltaTime;
         onTimeEvent?.Invoke(gameDuration);
         if (gameDuration <= 0)
         {
             onMiniGameEnd?.Invoke();
         }
     }

     private void Update()
     {
         if (_isGameActive)
         {
             TrackGameTime();
         }
     }

     public void IncrementDefectCounter()
     {
         if (_defectCount >= 9)
         {
             onMiniGameEnd?.Invoke();
             _isGameActive = false;
             return;
         }
         _defectCount++;
         onDefectEvent?.Invoke(_defectCount);
     }
    
}
