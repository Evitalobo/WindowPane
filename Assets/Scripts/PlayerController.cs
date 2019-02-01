using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Timers;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 15.0f;
    public Text dialogueUI;
    public bool mTrip = false;
    public bool mTripMovement = false;
    public int mTripAmount;
    public int mTripThreshold = 10;
    public float cycleCounter = 0;
    public Timer timer = new System.Timers.Timer();

    // Use this for initialization
    void Start()
    {
        mTripAmount = 0;
        Cursor.lockState = CursorLockMode.Locked;
        dialogueUI.text = "Lately I've been having nightmares where I've been trapped inside my house and see figures and shapes that morph into each other.";

    }

    // Update is called once per frame
    void Update()
    {
        cycleCounter++;
        float moveForwardBack = Input.GetAxis("Vertical") * moveSpeed;
        float moveToSide = Input.GetAxis("Horizontal") * moveSpeed;
        if (mTripMovement)
        {
            moveForwardBack += (float)(0.15 * (Math.Sin((cycleCounter / 100) * Math.PI)));
            moveToSide += (float)(0.25 * ((Math.Sin((cycleCounter / 70) + 0.5) * Math.PI))); // after 20 seconds has elapsed from the time of trippage
        }

        moveForwardBack *= Time.deltaTime;
        moveToSide *= Time.deltaTime;
        transform.Translate(moveToSide, 0, moveForwardBack);
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("t"))
        {
            Drink(); //just a test button to check if the timer worked
        }
    }

    public void Drink()
    {
        if (mTrip == false)
        {
            Wait(timer); // the first time tripping happens/trip button is pressed
        }
        mTrip = true;
        Debug.Log("trip = " + mTrip);
    }

    public void Wait(Timer timer)
    {
        timer.Interval = 20000; //timer stuff
        Debug.Log("timer set");
        timer.AutoReset = false;
        timer.Enabled = true;
        timer.Elapsed += OnTimedEvent;
        timer.Start();
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        mTripMovement = true;
        Debug.Log("timer complete");
        timer.Stop();
        timer.Dispose();
    }

    public void addTrip(int amount)
    {
        mTripAmount += amount;
        if (mTripAmount > mTripThreshold)
        {
            mTrip = true;
            mTripMovement = true;
        }
    }

    public bool IsTripping()
    {
        if (mTrip)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
