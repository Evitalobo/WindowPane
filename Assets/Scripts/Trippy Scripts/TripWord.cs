using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWord : TripItem
{
    public int mSpeed;
    public Vector3 mDestination;
    public int mXChangeOnTrip;
    public int mYChangeOnTrip;
    public int myZChangeOnTrip;
    // Start is called before the first frame update
    void Start()
    {
        mDestination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = mDestination - transform.position;
        Vector3 velocity = dir.normalized * mSpeed * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        this.transform.Translate(velocity);
    }

    public override void startTrip()
    {
        Debug.Log("Starting word trip");
        mDestination = new Vector3 (transform.position.x + mXChangeOnTrip, transform.position.y + mYChangeOnTrip, transform.position.z + myZChangeOnTrip);
    }

    public override void stopTrip()
    {
        mDestination = new Vector3(transform.position.x - mXChangeOnTrip, transform.position.y - mYChangeOnTrip, transform.position.z - myZChangeOnTrip);
    }
}
