using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other) {
        audioSource.Play();
    }
}