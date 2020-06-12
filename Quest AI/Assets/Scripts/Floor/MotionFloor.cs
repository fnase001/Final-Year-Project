using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionFloor : MonoBehaviour
{
    [SerializeField]
    // moving the floor toward another platform 
    private Transform moveTowards;
    // this is the start position 
    private Vector3 begin;
    [SerializeField]
    // smooth movement of the platform
    private float SMotion = 0.3f;
    // initial movement of the platform
    private float Motion;
    
    private bool SMotiontH;
    //check if the platform moves
    private bool get_Motion;
    // move the floor platform back to it initial poisiton
    private bool toward_Motion;

    [SerializeField]
    // half the distance 
    private float HGap = 15f;

    [SerializeField]
    // movement of a object when selected
    private bool ActionMotionBegin;

    [SerializeField]
    // how long it take to move the object.
    private float time = 1f;

    private FloorAudio music;
    // Start when the scrip is being loaded
    private void Awake()
    {
        begin = transform.position;
        Motion = SMotion;
        // adding sound when starting the game
        music = GetComponent<FloorAudio>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if(ActionMotionBegin)
        {
            Invoke("ActivateMotion", time);

        }
    }

   public void ActivateMotion()
    {
        get_Motion = true;
        // make the audio work when acitvate motion
        music.PlayAudio(true);
    }

    void TravelGround()
    {
        if(get_Motion)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowards.position,SMotion);
            if(Vector3.Distance(transform.position,moveTowards.position) <= HGap)
            {
                if(SMotiontH == false)
                {
                    SMotion = (SMotion / 2);
                    SMotiontH = true;

                }
            }
           // if the object has reached its destination 
        if(Vector3.Distance(transform.position,moveTowards.position) ==0f)
            {
                // wont move the object
                get_Motion = false;
                if(SMotiontH)
                {
                    SMotion = Motion;
                    SMotiontH = false;
                }
                music.PlayAudio(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        TravelGround();
    }
}
