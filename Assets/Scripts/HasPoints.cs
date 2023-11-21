using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPoints : MonoBehaviour
{
    // add public float variables for other objects that contain points
    public float enemyPoints;
    public float coinPoints;

    private LevelController levelController;
    public void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    public void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        levelController.LevelProgress(enemyPoints);
    }
    public void coinCollected()
    {
        Debug.Log("Coin Collected");
        levelController.LevelProgress(coinPoints);
    }
}
