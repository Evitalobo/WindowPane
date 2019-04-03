using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera FPSCamera;
    public ParticleSystem Effects;
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();  
        }
    }

    void Shoot(){
       
        Effects.Play();
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if(target != null){
                target.TakeDamage(damage);
            }
        }
      
    }
}
