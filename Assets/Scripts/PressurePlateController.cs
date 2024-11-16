using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public Vector3 actionNotDone;
    public Vector3 actionDone;
    private Vector3 targetPosition;
    public float moveSpeed = 2f;

    // Public variables
    public float weightThreshold = 10f;  // Weight limit to trigger the action
    public GameObject targetObject;      // The object to act upon (e.g., a door)

    // Stores the total weight of objects on top
    private float totalWeight = 0f;

    // Keeps track of objects on top of this GameObject
    public List<Rigidbody2D> objectsOnTop = new List<Rigidbody2D>();

    // Whether the action has already been triggered
    private bool actionTriggered = false;

    private void Start()
    {
        if (targetObject != null)
        {
            targetPosition = targetObject.transform.position;
            actionNotDone = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
            actionDone = new Vector3(targetPosition.x, targetPosition.y - 50, targetPosition.z); // Example Y move
        }
    }

    // Trigger enter to detect new objects in 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.attachedRigidbody;
        if (rb != null && !objectsOnTop.Contains(rb))
        {
            objectsOnTop.Add(rb);
            UpdateTotalWeight();
        }
    }

    // Trigger exit to remove objects no longer on top in 2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.attachedRigidbody;
        if (rb != null && objectsOnTop.Contains(rb))
        {
            objectsOnTop.Remove(rb);
            UpdateTotalWeight();
        }
    }

    // Updates the total weight of objects
    private void UpdateTotalWeight()
    {
        totalWeight = 0f;
        foreach (Rigidbody2D rb in objectsOnTop)
        {
            totalWeight += rb.mass;
        }

        // Check if the weight exceeds the threshold and the action hasn't been triggered yet
        if (totalWeight > weightThreshold && !actionTriggered)
        {
            TriggerAction();
            actionTriggered = true;
        }
        else if (totalWeight <= weightThreshold && actionTriggered)
        {
            ResetAction();
            actionTriggered = false;
        }
    }

    // Action triggered when weight exceeds the threshold
    private void TriggerAction()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, actionDone, Time.deltaTime * moveSpeed);
        }
    }

    // Action reset when weight drops below the threshold
    private void ResetAction()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, actionNotDone, Time.deltaTime * moveSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        // Optional: Visualize the weight detector for debugging
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.1f);
    }
}
