using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerFootstep : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;

        }
    }
}
