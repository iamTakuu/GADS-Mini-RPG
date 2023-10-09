using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MiniGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _defectCounter;
    private int _defectCount;
   
    public void IncrementCounter(int count)
    {
        _defectCounter.text = count.ToString();
        _defectCounter
            .DOScale( 4f, 0.2f)
            .OnComplete(() => _defectCounter.DOScale(2.7413f, 0.2f));
    }
    public void OnGameOver()
    {
        _defectCounter.text = "Game Over";
        //Time.timeScale = 0;
    }
}
