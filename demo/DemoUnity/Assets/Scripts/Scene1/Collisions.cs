using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Zones zone;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip collisionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("explosion");

            // Play sound
            if (audioSource != null && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            if (zone != null)
            {
                zone.TriggerExplosion();
            }
            else
            {
                Debug.LogWarning("Zones reference not assigned in Inspector!");
            }
        }
    }
}
