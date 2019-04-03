using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Laser
{


    public float deaths=0;
    public float health = 50f;
    public ParticleSystem blood;
    public GameObject bloodPool;


    public void TakeDamage (float amount){
        health -= amount;
        if(health <= 0f){
            //need to instantiate effects and enemies at some point- hella inefficient code currently
            blood.transform.position = this.transform.position;
            blood.Play();
            killCt.kills += 1;
           // deaths=deaths +1;
           // kills.text = deaths.ToString("Kills: " + deaths);
            GameObject impact = Instantiate(bloodPool, hit.point, Quaternion.LookRotation(hit.normal));
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
