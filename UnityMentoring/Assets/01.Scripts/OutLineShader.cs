using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineShader : MonoBehaviour
{
    Color color = Color.yellow;

    public int outLineSize = 3;
    
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OutLine(bool isClick){

        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

        spriteRenderer.GetPropertyBlock(materialPropertyBlock);
        if(isClick){

            materialPropertyBlock.SetFloat("_Outline", 1f);
            materialPropertyBlock.SetColor("_OutlineColor", color);
            materialPropertyBlock.SetFloat("_OutlineSize", outLineSize);

        }
        else{

            materialPropertyBlock.SetFloat("_Outline", 0);
        }

        spriteRenderer.SetPropertyBlock(materialPropertyBlock);
        
    }
}
