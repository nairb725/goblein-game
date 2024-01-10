using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepSound;

    [SerializeField]
    private AudioSource crackGlowingStick;

    [SerializeField]
    private AudioSource BallWalkSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Default Walk
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;

        }
        // When you crack Stick
        if (Input.GetKey(KeyCode.E))
        {
            crackGlowingStick.Play();
        }

    }
}