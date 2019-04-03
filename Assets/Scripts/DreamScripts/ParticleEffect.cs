using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
   public ParticleSystem Burst;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem Burst = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void CheeseExplode()
    {
        Burst.Play();
        Debug.Log("particleplay");
    }
}
