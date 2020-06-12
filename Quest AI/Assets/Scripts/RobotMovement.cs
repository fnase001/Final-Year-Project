using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    // variable for the player
    // * movement of the player and position
    private Rigidbody rigidb;
    public float movementSpeed = 3f;
    private float movementS = 15f;
    private Camera CameraMain;
    private Vector3 targetF;
    private bool movement;
    private Vector3 pos;
    

    // Start when the scrip is being loaded
    private void Awake()
    {
        CameraMain = Camera.main;
        rigidb = GetComponent<Rigidbody>();
        targetF = transform.forward;

        
    }
    
    // Update is called once per frame
    void Update()
    {
        InputG();
        ForwardUpdate();

    }
    // FixedUpdate is called every fixed framerate frame
    private void FixedUpdate()
    {
        MovementPlayer();

    }
    void InputG()
    {
        // while holding  the click function on the phone screen you can move the player 
        if(Input.GetMouseButtonDown(0))
        {
            movement = true;
        }
        // when releasing the click function
        else if(Input.GetMouseButtonUp(0))
        {
            movement = false;
        }
    }
    void ForwardUpdate()
    {
        // moving the object forward
        transform.forward = Vector3.Slerp(transform.forward,targetF,Time.deltaTime * movementS);
    }
    void MovementPlayer()
    {
        // whiles moving the robot
        if(movement)
        {
            pos = new Vector3(Input.GetAxisRaw(AxisChange.MOUSE_X),0f,Input.GetAxisRaw(AxisChange.MOUSE_Y));
            // make the same direction but it length will allwayz be 1.0
            pos.Normalize();

            // make the position of the robot and multiplying the movment speed variable to make it move smoothly
            pos *= movementSpeed *Time.fixedDeltaTime;
            // this will rotate the robot relative to the camera Y rotation
            pos = Quaternion.Euler(0f, CameraMain.transform.eulerAngles.y,0f) * pos;
            rigidb.MovePosition(rigidb.position + pos);

            if (pos != Vector3.zero)
                targetF = Vector3.ProjectOnPlane(pos,Vector3.up);
        }

    }
}
