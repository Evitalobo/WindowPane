using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Timers;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    // The 'm' before variables denotes that they are a member/global variable
    public float mMoveSpeed = 15.0f;
    public float mRotateSpeed = 40f;
    public Text mDialogueUI;
    public bool mTrip = false;
    public bool mTripMovement = false;
    public int mTripAmount;
    public int mTripThreshold = 10;
    public int mTripCap = 30;
    public float mCycleCounter = 0;
    public Timer mTimer = new System.Timers.Timer();
    public AudioSource mBackground;    
    public AudioSource mRadioMessage;
    public AudioSource mMovementSound;
    public float mCurrentAudioTime;
    public AudioClip mNormalBGM;
    public AudioClip mTripBGM;
    public AudioClip mTileFootsteps;
    public AudioClip mCarpetFootsteps;
    public float mAudioTimer;
    public float mTotalTime;
    public int mFadeState; //0 not fading, 1 fading out, 2 fading in, 3 fading to low, 4 fading from low, 5 low, 6 fading out from low, 7 fading in to low
    public int mGameState; //0 start of game, 1 player has talked to cat while tripping
    public bool mMailState;
    public bool mBookState;
    public bool mRatState;
    public float moveForwardBack;
    public float moveToSide;
    float mLastTripStart;
    float mLastDecrease = 0;
    private float interpolator = 0;
    string floorTag;
    public PostProcessVolume mPPV;
    private ColorGrading colorGradingSettings;

    enum rotateType
    {
        snap,
        smooth
    }
    [SerializeField] private rotateType mRotateType;
    [SerializeField] private float mRotateThreshold; // The amount the joystick must be moved in order to be snapped
    [SerializeField] private int mRotateCooldown;
    [SerializeField] private int mSnapAmount;
    [SerializeField] private GameObject mCamera;
    private int mRotateCounter;
    
    

    // Use this for initialization
    void Start()
    {
        mRotateCounter = 0;
        mTotalTime = 20;
        mTripAmount = 0;
        Cursor.lockState = CursorLockMode.Locked;
        mDialogueUI.text = "";
        bool foundEffectSettings = mPPV.profile.TryGetSettings<ColorGrading>(out colorGradingSettings);
    }

    // Update is called once per frame
    void Update()
    {
        mCycleCounter++;
        checkRadioMessage();
        volumeChange();
        move();
        ActivateTrippyVisuals();
        // transform.Rotate((mCamera.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y) * Vector3.up);
        
        rotate();
        // Commenting this out so that there is not a timer for when you stop tripping.
        // Now in order to stop tripping something must explicitly call the stopTripping function
        // decrementTrip();
        checkCursor();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {        
            
            floorTag = hit.collider.tag;
        }
        if (floorTag == "Carpet")
        {
            if(mMovementSound.clip == mTileFootsteps) {
                Debug.Log("move to carpet");
                mMovementSound.Stop();
                mMovementSound.clip = mCarpetFootsteps;
                mMovementSound.Play();
            }
        } else if (floorTag == "Tile")
        {   
            if(mMovementSound.clip == mCarpetFootsteps) {
                Debug.Log("move to tile");
                mMovementSound.Stop();
                mMovementSound.clip = mTileFootsteps;
                mMovementSound.Play();
            }
        }
    }

    
    private void move()
    {
        moveForwardBack = Input.GetAxis("Vertical") * mMoveSpeed;
        moveToSide = Input.GetAxis("Horizontal") * mMoveSpeed;

        

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            mMovementSound.UnPause();
        } else {
            mMovementSound.Pause();
        }
        if (mTripMovement)
        {
            moveForwardBack += (float)(0.5 * (Math.Sin((mCycleCounter / 80) * Math.PI)));
            moveToSide += (float)(0.65 * ((Math.Sin((mCycleCounter / 60) * Math.PI)))); // after 20 seconds has elapsed from the time of trippage
        }

        moveForwardBack *= Time.deltaTime;
        moveToSide *= Time.deltaTime;
        Vector3 movement = moveForwardBack * mCamera.transform.forward;
        movement.y = 0;
        transform.position += movement;
        
        
    }

    private void rotate()
    {
        float rotate = Input.GetAxis("Horizontal") * mRotateSpeed;
        // Debug.Log("Rotate: " + rotate);
        
        if (mRotateType == rotateType.smooth)
        {
            transform.Rotate(rotate * Vector3.up * Time.deltaTime);
        } else if (mRotateType == rotateType.snap)
        {
            if (mRotateCounter > 0)
            {
                mRotateCounter--;
            }
            if (mRotateCounter == 0 && Math.Abs(Input.GetAxis("Horizontal")) > mRotateThreshold)
            {
                
                if (rotate > 0)
                {
                    Debug.Log("Trying to rotate");
                    
                    this.transform.Rotate(mSnapAmount * Vector3.up);
                    // mCamera.transform.Rotate(mSnapAmount * Vector3.up);
                }
                else
                {
                    Debug.Log("Trying to rotate");
                    
                    this.transform.Rotate(-mSnapAmount * Vector3.up);
                    // mCamera.transform.Rotate(-mSnapAmount * Vector3.up);
                }
                mRotateCounter = mRotateCooldown;
            }
        }
        
    }

    void checkCursor()
    {
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
            Wait(mTimer); // the first time tripping happens/trip button is pressed
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
        mTimer.Stop();
        mTimer.Dispose();
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
        swapMusic();


        Debug.Log("Starting to trip at time: " + mLastTripStart);
        StartCoroutine(ActivateTrippiness());
    }

    public void ActivateTrippyVisuals()
    {
        int min = 0;
        int max = 180;
        if (mTrip)
        {
            if (mPPV.weight >= 1)
            {
                if (interpolator == 1)
                {
                    interpolator = 0;
                    min = 180;
                    max = 0;
                }
                else if (interpolator == 0)
                {
                    //interpolator = 0;
                    min = 0;
                    max = 180;
                }
                interpolator += 0.05f * Time.deltaTime;
                colorGradingSettings.hueShift.value =  Mathf.Lerp(min, max, interpolator);
                
            } else
            {
                interpolator += 0.5f * Time.deltaTime;
                mPPV.weight = Mathf.Lerp(0, 1, interpolator);
                if (mPPV.weight == 0)
                    interpolator = 0;
            }
        }
    }

    IEnumerator ActivateTrippiness()
    {
        GameObject[] trippyItems = GameObject.FindGameObjectsWithTag("Trippy");
        
        Debug.Log("amount of trippy items: " + trippyItems.Length);
        for (int i = 0; i < trippyItems.Length; i++)
        {
            if (trippyItems[i].GetComponent<TripItem>() != null)
            {
                trippyItems[i].GetComponent<TripItem>().startTrip();
            }
            else
            {
                if (trippyItems[i].GetComponentInParent<TripItem>() != null)
                {
                    trippyItems[i].GetComponentInParent<TripItem>().startTrip();
                }
            }
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
        }
    }

    public void stopTripping()
    {
        mTrip = false;
        mTripMovement = false;
        GameObject[] trippyItems = GameObject.FindGameObjectsWithTag("Trippy");
        Debug.Log("amount of trippy items: " + trippyItems.Length);
        swapMusic();
        for (int i = 0; i < trippyItems.Length; i++)
        {
            if (trippyItems[i].GetComponent<TripItem>() != null)
            {
                trippyItems[i].GetComponent<TripItem>().stopTrip();
            } else
            {
                trippyItems[i].GetComponentInParent<TripItem>().stopTrip();
            }
                
        }
    }

    void decrementTrip()
    {
        // Remove 1 trip point every five seconds starting 20 seconds after you start tripping
        if (Time.time - mLastTripStart > 20)
        {
            if (Math.Floor(Time.time) % 5 == 0 && mTripAmount > 0 && mLastDecrease != Math.Floor(Time.time))
            {
                mLastDecrease = (float)Math.Floor(Time.time);
                addTrip(-1);
            }
        }
    }

    public bool IsTripping()
    {
        return mTrip;
    }


    public void swapMusic() 
    {           
        AudioFadeOut();
        
    }

    public void AudioFadeOut() 
    {
        if (mFadeState == 5) {
            mFadeState = 6;
            Debug.Log("Audio fading from low point");
        } else {
            mFadeState = 1;
            Debug.Log("Audio fading out");
        }      
        return;
    }

    public void AudioFadeIn() 
    {
        if (mFadeState == 6) {
            mFadeState = 7;
            Debug.Log("Audio fading in to low point");
        }
        else {
            mFadeState = 2;
            Debug.Log("Audio fading in");
        }        
        return;
    }

    public void AudioFaded()
    {        
        AudioClip toSwap = null;
        float switchTime = mBackground.time;
        float switchVolume = mBackground.volume;
        if(mBackground.clip == mNormalBGM) {
            toSwap = mTripBGM;
        } else if(mBackground.clip == mTripBGM) {
            toSwap = mNormalBGM;
        } else {
            toSwap = null;
        }
        mBackground.Stop();
        mBackground.clip = toSwap;
        mBackground.Play();
        mBackground.time = switchTime;        
        AudioFadeIn();
        return;
    }

    public void volumeChange()
    {
        mCurrentAudioTime = mBackground.time;
        if (mFadeState != 0)
        {
            if (mFadeState == 1)
            {
                if (mBackground.volume > 0.0f)
                {
                    mBackground.volume -= Time.deltaTime;
                }
                else
                {
                    mBackground.volume = 0.0f;
                    mFadeState = 0;
                    AudioFaded();
                }
            }
            else if (mFadeState == 2 || mFadeState == 4)
            {
                if (mBackground.volume < 1.0f)
                {
                    mBackground.volume += Time.deltaTime;
                }
                else
                {
                    mBackground.volume = 1.0f;
                    mFadeState = 0;
                }
            }
            else if (mFadeState == 3) 
            {
                if (mBackground.volume > 0.2f)
                {
                    mBackground.volume -= Time.deltaTime * 4;
                }
                else{
                    mBackground.volume = 0.2f;
                    mFadeState = 5;
                    startRadioMessage();
                }
            }
            else if (mFadeState == 6)
            {
                if (mBackground.volume > 0.0f)
                {
                    mBackground.volume -= Time.deltaTime / 5f;
                }
                else
                {
                    mBackground.volume = 0.0f;
                    mFadeState = 5;
                    AudioFaded();
                }
            }
            else if (mFadeState == 7) {
                if (mBackground.volume < 0.2f)
                {
                    mBackground.volume += Time.deltaTime / 5f;
                }
                else 
                {
                    mBackground.volume = 0.2f;
                    mFadeState = 5;
                }
            }
        }
    }

    public void checkRadioMessage() 
    {
        mTotalTime += Time.deltaTime;
        if(mTotalTime >= 30) {
            mTotalTime -= 30;
            mFadeState = 3;
        }
        if(mFadeState == 5) {
            if(mRadioMessage.isPlaying == false) {
                mFadeState = 4;
            }
        }
    }

    public void startRadioMessage()
    {
        mRadioMessage.Play();
    }
}
