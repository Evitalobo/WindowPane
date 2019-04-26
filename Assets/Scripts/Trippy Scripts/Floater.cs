using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : TripItem
{

    Vector3 mOriginalPosition;
    public float mForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void startTrip()
    {
        mOriginalPosition = this.transform.position;
        Rigidbody body = this.GetComponent<Rigidbody>();
        body.AddForce(0, mForce, 0);
        Debug.Log("It's a floater!");
    }

    public override void stopTrip()
    {
        Rigidbody body = this.GetComponent<Rigidbody>();
        body.AddForce(0, -mForce, 0);
        this.transform.position = mOriginalPosition;
    }
}
