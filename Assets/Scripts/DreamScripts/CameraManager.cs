using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   
    public Camera Camera2;
 

  
    // Start is called before the first frame update
    void Start()
    {


        Camera2.GetComponent<Camera>().enabled = true;
       


    }

 



}
