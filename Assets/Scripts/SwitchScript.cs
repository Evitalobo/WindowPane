using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : Item
{
    public GameObject light;
    bool ON = false;

    void onEnable()
    {
        OnClick += toggleLight;
    }

    void onDisable()
    {
        OnClick -= toggleLight;
    }

    void toggleLight()
    {
        Debug.Log("in Toggle LIGHT");
        if (ON)
        {
            ON = false;
        }
        else
        {
            ON = true;
        }
        light.SetActive(ON);
    }
}
