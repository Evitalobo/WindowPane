using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAt : MonoBehaviour
{

    public Transform playerObj;
  

    void Update()
    {
        transform.LookAt(playerObj);
    }
}
