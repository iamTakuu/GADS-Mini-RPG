using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _timerText;
   
   public void UpdateTimer(float time)
   {
      _timerText.text = time.ToString("F2");
   }
}
