using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelController : MonoBehaviour
{
    float currentLevel;
    float currentPoints;
    [SerializeField] float levelUpRequirement;
    [SerializeField] float _incrementBy;
    [SerializeField] private TextMeshProUGUI levelText;
    public Slider levelSlider;

    bool _canLevelUp;

    private void Awake()
    {
        currentPoints = 0;
        currentLevel = 1;
        levelText.text = "Level: " + currentLevel.ToString();
    }
    private void Start()
    {
        levelSlider.maxValue = levelUpRequirement;
        levelSlider.value = currentPoints;
    }
    void Update()
    {
        if (currentPoints >= levelUpRequirement)
        {
            _canLevelUp = true;
            LevelUpSequence();
        }
    }
    void LevelUpSequence()
    {
        //Updates current level and is reflected on the UI
        currentLevel += 1;
        levelText.text = "Level: " + currentLevel.ToString();

        //the amount of points needed to level up again goes up by the increment amount
        levelUpRequirement += _incrementBy;

        // Reset current points, _canLevelUp status, level slider bar,
        currentPoints = 0;
        _canLevelUp = false;  
        levelSlider.value = currentPoints;

        //level slider bar's max value increases by the new levelUpRequirement
        levelSlider.maxValue = levelUpRequirement;
        Debug.Log("Points needed: " + levelUpRequirement);
    }

    public void LevelProgress(float addPoints)
    {
        currentPoints += addPoints;
        levelSlider.value = currentPoints;
        Debug.Log("Current Points: " +  currentPoints);
    }
}
