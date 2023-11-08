using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    float CurrentLevel;
    float currentPoints;
    [SerializeField] float levelUpRequirement = 10;
    [SerializeField] float _incrementBy = 10;

    bool _canLevelUp = false;

    private void Awake()
    {
        currentPoints = 0;
        CurrentLevel = 0;
    }
    void Update()
    {
        if (currentPoints >= levelUpRequirement)
        {
            _canLevelUp = true;
        }

        if (_canLevelUp)
        {
            LevelUpSequence();
        }
    }
    void LevelUpSequence()
    {
        CurrentLevel += 1;
        levelUpRequirement += _incrementBy;
        currentPoints = 0;
        _canLevelUp = false;
    }

    void levelProgress(float addPoints)
    {
        currentPoints += addPoints;
        //reflect this info on UI
    }
}
