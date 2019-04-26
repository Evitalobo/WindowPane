using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSetup : MonoBehaviour
{

    public Camera cameraB;

    public Material cameraMatB;


    // Start is called before the first frame update
    void Start()
    {
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraB.targetTexture.vrUsage = VRTextureUsage.TwoEyes;
        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}

