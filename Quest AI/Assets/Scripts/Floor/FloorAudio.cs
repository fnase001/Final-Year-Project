using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAudio : MonoBehaviour
{
         private AudioSource music;

    // Start when the scrip is being loaded
    void Awake()
        {
            music = GetComponent<AudioSource>();
        }

      public void PlayAudio(bool start)
      {
         if (start)
         {
              music.Play();
          }
          else
          {
           music.Stop();
           }
        }
    }
