using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MiniGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _defectCounter;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private CanvasGroup _gameOverCanvasGroup;
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
        _defectCounter.text = "X";
        _gameOverCanvasGroup.DOFade(1, 1.5f);
        //Time.timeScale = 0;
    }
    public void FadeInUI()
    {
        _canvasGroup.DOFade(1, 0.5f);
    }
}
