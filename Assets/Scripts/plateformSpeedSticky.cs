using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowPlatform : MonoBehaviour
{
    private Transform platformTransform; // Store the platform's transform

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Store the platform's transform on collision enter
            platformTransform = collision.transform;
            transform.SetParent(platformTransform); // Set player's parent to the platform
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Ensure the player is no longer a child of the platform on exit
            if (transform.parent == platformTransform)
            {
                transform.parent = null;
                platformTransform = null; // Reset platform reference
            }
        }
    }

    private void FixedUpdate()
    {
        // Ensure the player's position is relative to the platform
        if (transform.parent == platformTransform && platformTransform != null)
        {
            transform.position += platformTransform.position - transform.position;
        }
    }
}
