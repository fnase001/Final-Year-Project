using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPl : MonoBehaviour
{

    [SerializeField]
    private Vector3 RPlatform;
    // rotation of the platform
    private Quaternion RMovement;

    [SerializeField]
    private float MovementS = 1f;

    [SerializeField]
    private bool use_Movement;

    private bool back_To_Initial_Rotation;

    [SerializeField]
    private float FindTime = 5f;

    private FloorAudio music;
    // Start when the scrip is being loaded
    void Awake()
    {
        RMovement = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlatform();
    }

    void RotatePlatform()
    {
        if (use_Movement)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(RPlatform.x, RPlatform.y, RPlatform.z),
                    MovementS * Time.deltaTime);

        }
    }

    public void ActivateRotation()
    {
        // rotate platform use the sound 
        if (!use_Movement)
        {

            use_Movement = true;

            music.PlayAudio(true);

            // deactivate the sound and roatation 
            Invoke("FindR", FindTime);

        }

    } // activate rotaton

    void FindR()
    {

        use_Movement = false;
        music.PlayAudio(false);

    } // deactivate rotation
}
