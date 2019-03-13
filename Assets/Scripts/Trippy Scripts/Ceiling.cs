using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : TripItem
{

    Vector3 mPosition;
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
        int initialTime = (int)Mathf.Floor(Time.time);
        int lastTime = 0;
        Debug.Log("ceiling start trip");
        mPosition = this.transform.position;
        while (this.transform.position.y < 50)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);

        }
    }

    public override void stopTrip()
    {
        this.transform.position = mPosition;
    }
}
