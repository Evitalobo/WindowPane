using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public int mMoveSpeed = 8;
    float moveForwardBack;
    float moveToSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        moveForwardBack = Input.GetAxis("Vertical") * mMoveSpeed;
        moveToSide = Input.GetAxis("Horizontal") * mMoveSpeed;
        moveForwardBack *= Time.deltaTime;
        moveToSide *= Time.deltaTime;
        transform.Translate(moveToSide, 0, moveForwardBack);
    }
}
