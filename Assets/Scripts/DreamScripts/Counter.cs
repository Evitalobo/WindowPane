using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Counter: Lever
{

    public float timeLeft = 120.0f;
    public Text timer; 



    void Update()
    {


        timer.text = (timeLeft).ToString("0");
        if (DoorOpen)
        {
            timeLeft = Time.deltaTime;

        }
        else{
            timeLeft -= Time.deltaTime;

        }

        if (timeLeft < 0 && DoorOpen==false)
        {
            SceneManager.LoadScene(2);
        }
    }
}
