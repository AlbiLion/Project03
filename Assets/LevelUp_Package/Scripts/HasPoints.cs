using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPoints : MonoBehaviour
{
    // Add public float variables for other objects that contain points
    public float enemyPoints;
    public float coinPoints;

    private LevelController levelController;
    public void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    // Add more public methods as needed for other point collection types
    public void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        levelController.LevelProgress(enemyPoints);
    }
    public void CoinCollected()
    {
        Debug.Log("Coin Collected");
        levelController.LevelProgress(coinPoints);
    }
}
