using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Target" tag
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject); // Destroy the target
            Destroy(gameObject); // Destroy the bullet

            //Calls HasPoints script and EnemyDestroyed Method, Point allocation is handled there
            HasPoints hasPoints = FindObjectOfType<HasPoints>();
            hasPoints.EnemyDestroyed();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
