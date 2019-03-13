using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBubble : MonoBehaviour
{
    // Public vars
    public Canvas canvas;

    // Material related vars
    public Shader noZTestShader;
    private Material mat;
    private Material newMaterial;
    private Component[] images;
    private Text[] texts;

    
    //public dialogueBubble()
    //{
    //    Instantiate(GameObject);
    //}

    void Start()
    {
        //noZTestShader = Shader.Find("Assets/Scripts/Shaders/noZTest");
        //applyShader();
        // Copy default UI material and change shader
        mat = Canvas.GetDefaultCanvasMaterial();
        newMaterial = Material.Instantiate(mat);
        newMaterial.shader = noZTestShader;
        // Apply new material to all UI 
        images = GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            print(img.material);
            print(newMaterial);
            img.material = newMaterial;
        }
        //gameObject.GetComponent<Text>().material = newMaterial;
    }

    void applyShader()    {
        
    }

  
}
