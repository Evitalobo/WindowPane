using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCatWord : TripItem
{
    public int mSpeed;
    public Vector3 mDestination;
    public int mXChangeOnTrip;
    public int mYChangeOnTrip;
    public int myZChangeOnTrip;
    public GameObject mCatClock;
    public GameObject mPlayer;
    public bool mTripMoved;
    // Start is called before the first frame update
    void Start()
    {
        mDestination = transform.position;
        mTripMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = mDestination - transform.position;
        Vector3 velocity = dir.normalized * mSpeed * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        this.transform.Translate(velocity);
        if(mPlayer.GetComponent<PlayerController>().mTrip) {
            if(mCatClock.GetComponent<CatClock>().mHeardConversation == 2) {
                if(!mTripMoved) {
                    beginTrip();
                }
            }
        } else {
            endTrip();
        }

    }

    public void beginTrip()
    {       
        Debug.Log("Starting word trip");
        mTripMoved = true;
        mDestination = new Vector3 (transform.position.x + mXChangeOnTrip, transform.position.y + mYChangeOnTrip, transform.position.z + myZChangeOnTrip);
    }

    public void endTrip()
    {
        if(mTripMoved == true) {
            mDestination = new Vector3(transform.position.x - mXChangeOnTrip, transform.position.y - mYChangeOnTrip, transform.position.z - myZChangeOnTrip);
            mTripMoved = false;
        }
    }
}
