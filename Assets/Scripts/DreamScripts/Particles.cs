using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
   public ParticleSystem Burst;
 
    public void CheeseExplode(){
        Debug.Log("Playing Burst");
        Burst.Play();

    }
}
