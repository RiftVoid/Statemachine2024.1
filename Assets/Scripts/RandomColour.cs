using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColour : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    private Renderer rendererer;
    
    void Awake()
    {
        rendererer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }

    public void PickRandom()
    {
        Color randomColour = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColour);
        rendererer.SetPropertyBlock(propertyBlock);
    }

    private float H = 0;
    public void SlideColour()
    {
        H += 0.1f * Time.deltaTime;
        if (H >= 1)
        {
            H = 0;
        }
        Color newColour = Color.HSVToRGB(H,1,1);
        propertyBlock.SetColor("_Color", newColour);
        rendererer.SetPropertyBlock(propertyBlock);
    }
}
