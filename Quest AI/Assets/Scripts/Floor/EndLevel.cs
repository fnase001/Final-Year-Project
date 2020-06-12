using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private string LevelChange;

    [SerializeField]
    private float timeforlevel = 2f;

    private bool FinishedGame;

    private FloorAudio music;
    // Start when the scrip is being loaded
    void Awake()
    {
        music = GetComponent<FloorAudio>();
    }
    // Will go to the next level
    void NextLevel()
    {
        SceneManager.LoadScene(LevelChange);
    }

    void OnTriggerEnter(Collider target)
    {

        if (target.CompareTag(PlayerTag.PLAYER_TAG))
        {

            if (!FinishedGame)
            {

                FinishedGame = true;

                music.PlayAudio(true);

                if (!LevelChange.Equals(""))
                {
                    Invoke("NextLevel", timeforlevel);
                }

            }

        }

    }
}
