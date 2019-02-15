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
    public int mTripCap = 30;
    public float cycleCounter = 0;
    public Timer timer = new System.Timers.Timer();
    float mLastTripStart;
    float mLastDecrease = 0;

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

        // Remove 1 trip point every five seconds starting 20 seconds after you start tripping
        if (Time.time - mLastTripStart > 20)
        {
            if (Math.Floor(Time.time) % 5 == 0 && mTripAmount > 0 && mLastDecrease != Math.Floor(Time.time))
            {
                mLastDecrease = (float) Math.Floor(Time.time);
                addTrip(-1);
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
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
        Debug.Log("mTripAmount: " + mTripAmount + " amount adding: " + amount);
        if (mTripAmount == 0 && amount < 0)
        {
            Debug.Log("Can't remove trip amount from 0");
            return;
        }
        if (mTripAmount < mTripCap) {
            mTripAmount += amount;
        }
        if (mTripAmount > mTripThreshold)
        {
            if (!mTrip)
            {
                startTripping();
            }
        } else
        {
            if (mTrip)
            {
                stopTripping();
            }
        }
    }

    public void startTripping()
    {
        mTrip = true;
        mTripMovement = true;
        mLastTripStart = (float) Math.Floor(Time.time);
        GameObject[] trippyItems = GameObject.FindGameObjectsWithTag("Trippy");
        Debug.Log("amount of trippy items: " + trippyItems.Length);
        for (int i = 0; i < trippyItems.Length; i++)
        {
            trippyItems[i].GetComponent<TripItem>().startTrip();
        }
        Debug.Log("Starting to trip at time: " + mLastTripStart);
    }

    public void stopTripping()
    {
        mTrip = false;
        mTripMovement = false;
        GameObject[] trippyItems = GameObject.FindGameObjectsWithTag("Trippy");
        Debug.Log("amount of trippy items: " + trippyItems.Length);
        for (int i = 0; i < trippyItems.Length; i++)
        {
            trippyItems[i].GetComponent<TripItem>().stopTrip();
        }
    }

    public bool IsTripping()
    {
        return mTrip;
    }
}
