using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefectMeter : MonoBehaviour
{
    [SerializeField] private Image defectImage;
    [SerializeField] private List<Sprite> defectSprites;
    
    private int currentSpriteIndex;
    private int maxSprites;
    private bool gameEnded;

    private void Start()
    {
        maxSprites = defectSprites.Count;
        defectImage.sprite = defectSprites[0];
    }

    public void UpdateDefectMeter(int count)
    {
        if (!gameEnded)
        {
            if (count >= 10)
            {
                gameEnded = true;
                defectImage.sprite = defectSprites[maxSprites - 1];
            }else if (count % 2 == 0)
            {
                defectImage.sprite = defectSprites[currentSpriteIndex];
                currentSpriteIndex++;
            }
           
        }
    }
}
