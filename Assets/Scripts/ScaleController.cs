using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float scale = 1f;
    private Vector3 scaledVector;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Apply power-up to any object that collides with this power-up
        ApplyPowerUp(other.gameObject);
    }

    private void ApplyPowerUp(GameObject targetObject)
    {
        scaledVector = new Vector3(scale, scale, 0f);
        scaledVector.x *= targetObject.transform.localScale.x;
        scaledVector.y *= targetObject.transform.localScale.y;

        // Get the Rigidbody2D component
        Rigidbody2D rb = targetObject.GetComponent<Rigidbody2D>();
        
        // Apply the mass change to the object
        rb.mass *= scale;

        // Apply the scale change to the object
        targetObject.transform.localScale = scaledVector;

        // Destroy the power-up object after applying the effect
        Destroy(gameObject);
    }
}
