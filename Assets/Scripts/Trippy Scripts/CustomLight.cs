using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomLight : TripItem
{

    public bool isTripping;
    Light light;
    int cycleCounter;
    ClassManager mClassManager;
    public int mIntensity;


    // Start is called before the first frame update
    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        light = this.GetComponent<Light>();
        mIntensity = 1;
        cycleCounter = 7500;
    }

    // Update is called once per frame
    void Update()
    {
        cycleCounter++;
        Vector2 randomNum = new Vector2(UnityEngine.Random.Range(-mIntensity, mIntensity), UnityEngine.Random.Range(-mIntensity,mIntensity));
        if (isTripping)
        {
            light.intensity = mIntensity;
            light.transform.localPosition = new Vector3((float)(Math.Sin(cycleCounter / 75 * Math.PI) + mIntensity), (float)(Math.Sin(cycleCounter / 75 * Math.PI) + mIntensity), (float)(Math.Sin(cycleCounter / 75 * Math.PI) + mIntensity));
            light.shadowStrength = 1;
            light.transform.localRotation = new Quaternion(light.transform.localRotation.x, Mathf.PingPong(cycleCounter, 360), light.transform.localRotation.z, light.transform.localRotation.w);
            light.range = (float) ((mIntensity * Math.Sin(cycleCounter / 75 * Math.PI) + mIntensity));
            light.color = new Color((float) (mIntensity * Math.Sin(cycleCounter / 100 * Math.PI)), Mathf.PingPong(cycleCounter/2, 200), Mathf.PingPong(cycleCounter/2, 250));
        } else
        {
            light.intensity = 0;
        }
    }

    public override void startTrip()
    {
        isTripping = true;
    }

    public override void stopTrip()
    {
        isTripping = false;
    }
}
