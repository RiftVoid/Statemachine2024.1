using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    private Renderer renderer;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }
    
    public void PickRandom()
    {
        Color randomColour = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColour);
        renderer.SetPropertyBlock(propertyBlock);
        
    }
}
