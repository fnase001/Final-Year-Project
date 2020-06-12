using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraMove = 10f;
    public float cameraRotation = 15f;

    private Transform player;

    private Vector3 playerFor;

    // Start when the scrip is being loaded
    private void Awake()
    {
        player = GameObject.FindWithTag(CameraTag.CAMERA_TAG).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerFor = transform.forward;
        playerFor.y = 0f;
        Teleport();
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }
    void Teleport()
    {
        // the game move the camera to the target position whhere the player is
        if(player != null)
        {
            transform.position = player.position;

        }
        Vector3 movement = playerFor;
        movement.y = transform.forward.y;
        transform.forward = movement;
    }

    void GoToPlayer()
    {
        if(player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * cameraMove);
        }
        // making the Y axis of the camera follow the player Y axis position 
        Vector3 movement = transform.forward;
        movement.y = 0f;
        movement = Vector3.Slerp(movement,playerFor,Time.deltaTime * cameraRotation);
        movement.y = transform.forward.y;
        transform.forward = movement;

    }
}
