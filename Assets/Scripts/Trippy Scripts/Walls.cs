using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : TripItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void startTrip ()
    {
        int initialTime = (int) Mathf.Floor(Time.time);
        int lastTime = 0;
        Debug.Log("walls start trip");
        while (this.transform.localScale.y < 20)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y * 1.01f, this.transform.localScale.z);

        }
    }

    public override void stopTrip()
    {
        int initialTime = (int)Mathf.Floor(Time.time);
        int lastTime = 0;
        while (this.transform.localScale.y > 1)
        {
            lastTime = (int)Mathf.Floor(Time.time);
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y * 0.999f, this.transform.localScale.z);
        }
    }
}
