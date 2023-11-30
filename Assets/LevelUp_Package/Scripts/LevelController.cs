using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelController : MonoBehaviour
{
    float currentLevel;
    float currentPoints;
    [SerializeField] ParticleSystem levelUpParticles;
    [SerializeField] AudioSource levelUpAudio;
    [SerializeField] float levelUpRequirement;
    [SerializeField] float incrementBy;
    [SerializeField] private TextMeshProUGUI levelText;
    public Slider levelSlider;

    bool canLevelUp;


    //Player starts game at level 1, and has 0 points in the beginning
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

    /* Continually checks if the player has enough points to level up
    If there are enough points to level up, the LevelUpSequence method is called */
    void Update()
    {
        if (currentPoints >= levelUpRequirement)
        {
            canLevelUp = true;
            LevelUpSequence();
        }
    }
    void LevelUpSequence()
    {
        //Updates current level and is reflected on the UI
        currentLevel += 1;
        levelText.text = "Level: " + currentLevel.ToString();

        // If there is a particle system, play
        if (levelUpParticles != null)
        {
            levelUpParticles.Play();
        }

        // If there is an audio system, play
        if (levelUpAudio != null)
        {
            AudioSource newLevelUpSound = Instantiate(levelUpAudio, transform.position, Quaternion.identity);
            Destroy(newLevelUpSound.gameObject, newLevelUpSound.clip.length);
        }

        //the amount of points needed to level up again goes up by the increment amount
        levelUpRequirement += incrementBy;

        // Reset current points, _canLevelUp status, level slider bar,
        currentPoints = 0;
        canLevelUp = false;
        levelSlider.value = currentPoints;

        //level slider bar's max value increases by the new levelUpRequirement
        levelSlider.maxValue = levelUpRequirement;
        Debug.Log("Points needed: " + levelUpRequirement);
    }

    //Tracks level progression and displays info on the UI
    public void LevelProgress(float addPoints)
    {
        currentPoints += addPoints;
        levelSlider.value = currentPoints;
        Debug.Log("Current Points: " + currentPoints);
    }
}