using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killCt : MonoBehaviour
{
    public static int kills;
    Text killAmt;
    public Transform player;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        killAmt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killAmt.text = ("Kills: " + kills);
      
    }
}
