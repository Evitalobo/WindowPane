using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCam : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    GameObject player;
    ClassManager mClassManager;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
      
    }
	
	// Update is called once per frame
	void Update () {
        if (!mClassManager.paused())
        {
            var viewDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            viewDelta = Vector2.Scale(viewDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, viewDelta.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, viewDelta.y, 1f / smoothing);
            mouseLook += smoothV;

            if (Mathf.Abs(-mouseLook.y) < 90)
            {
                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            }
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
        
	}
}
