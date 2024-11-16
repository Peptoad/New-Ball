using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Grow, Shrink }
    public PowerUpType powerUpType;

    public Vector3 growthScale = new Vector3(1.5f, 1.5f, 1);
    public Vector3 shrinkScale = new Vector3(0.5f, 0.5f, 1);

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Apply power-up to any object that collides with this power-up
        ApplyPowerUp(other.gameObject);
    }

    private void ApplyPowerUp(GameObject targetObject)
    {
        // Determine the target scale based on the power-up type
        Vector3 targetScale = powerUpType == PowerUpType.Grow ? growthScale : shrinkScale;

        // Get the Rigidbody2D component
        Rigidbody2D rb = targetObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Calculate the volume ratio between the new scale and the original scale
            float originalVolume = targetObject.transform.localScale.x * targetObject.transform.localScale.y;
            float newVolume = targetScale.x * targetScale.y;

            float scaleFactor = newVolume / originalVolume;

            // Scale the mass proportionally
            rb.mass *= scaleFactor;
        }

        // Apply the scale change to the object
        targetObject.transform.localScale = targetScale;

        // Destroy the power-up object after applying the effect
        Destroy(gameObject);
    }
}
