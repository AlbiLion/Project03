using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    // Reference to the LevelController script
    public LevelController levelController;

    private void Start()
    {
        // Ensure that the LevelController script is assigned to the levelController variable
        if (levelController == null)
        {
            Debug.LogError("LevelController not assigned to EnemyController. Please assign it in the Inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }
    private void ShootRaycast()
    {
        // Perform a raycast from the camera's position forward
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hits an object tagged as "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                // Destroy the enemy
                Destroy(hit.collider.gameObject);

                // Call the LevelProgress function in the LevelController script with a float value of 10
                levelController.LevelProgress(10f);
            }
        }
    }
}
