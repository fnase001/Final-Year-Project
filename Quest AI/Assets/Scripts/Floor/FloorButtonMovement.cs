using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonMovement : MonoBehaviour
{
    private MovingPl MovingPl;
    // Start when the scrip is being loaded
    void Awake()
    {
        MovingPl = GetComponentInParent<MovingPl>();
    }

    void OnTriggerEnter(Collider target)
    {
        // when the player collide to the object it will activate

        if (target.CompareTag(PlayerTag.PLAYER_TAG))
        {
            MovingPl.ActivateRotation();
        }

    }
}
