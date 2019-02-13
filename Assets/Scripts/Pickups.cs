using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour {
  /*  private PlayerController player;
    [SerializeField]
    [Tooltip("Camera used by player")]
    private new Camera camera;
    [SerializeField]
    [Tooltip("Layer of items to be picked up")]
    private LayerMask layerMask;
    [SerializeField]
    [Tooltip("Layer of items to be picked up")]
    private LayerMask layerMask2;
    [SerializeField]
    [Tooltip("Layer of items to be picked up")]
    private LayerMask layerMask3;
    private GameObject Picked;
    private Item state;
    public Text dialogueUI;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        state = new Item();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 15f, layerMask))
            {
                Picked = hitInfo.collider.gameObject;
                Picked.SetActive(false);
                state = player.GetComponent<Item>();
                state.flashlight = true;
                dialogueUI.text = "<b>You picked up the blacklight flashlight</b>";
                Debug.Log("flashlight = " + state.flashlight);
            }
            if (Physics.Raycast(ray, out hitInfo, 15f, layerMask2))
            {
                Picked = hitInfo.collider.gameObject;
                Picked.SetActive(false);
                state = player.GetComponent<Item>();
                state.glass = true;
                Debug.Log("glass = " + state.glass);
            }
            if (Physics.Raycast(ray, out hitInfo, 15f, layerMask3))
            {
                Picked = hitInfo.collider.gameObject;
                state = player.GetComponent<Item>();
                state.sink = true;
                Debug.Log("sink = " + state.sink);
            }

        }
        if(state.sink == true)
        {
            if(state.glass == true)
            {
                dialogueUI.text = "<b>You fill up your glass with water</b>";
                state.water = true;
            }
            else
            {
                dialogueUI.text = "I need a glass to hold the water";
                state.sink = false;
            }
        }
        if(state.glass == true)
        {
            if (state.water == false)
            {
                dialogueUI.text = "<b>You picked up a glass</b>\n I could fill it up with water";
            }
            else
            {
                if(player.mTrip == false)
                {
                    dialogueUI.text = "I could drink the water... \n <b>Drink the water? Press the enter/return key to drink</b>";
                    if (Input.GetButtonDown("Submit"))
                    {
                        player.Drink();
                    }
                }
                else
                {
                    dialogueUI.text = "I don't feel so good...";
                }

            }
        }

    } */
}
