using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    //current stats
    public float currentHealth;
    public float currentMaxHealth;
    [HideInInspector]
    public float currentHpRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentVibration;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentBpmInterval;
    public float currentMagnet;



    

    //Experience and level of the player

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [Header("I-Frames")]
    public float invincibiltyDuration;
    float invincibilityTimer;
    bool isInvincible;

    public List<LevelRange> levelRanges;

    void Awake()
    {
        //Assign the variables
        currentHealth = characterData.MaxHealth;
        currentMaxHealth = characterData.MaxHealth;
        currentHpRecovery = characterData.HpRecovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentVibration = characterData.Vibration;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentBpmInterval = characterData.BpmInterval;
        currentMagnet = characterData.Magnet;
    }
    void Start()
    {
        //Initialize the experience cap as the first experience cap increase
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -=Time.deltaTime;
        }
        //If the invincibility time has reached 0, set the invincibility flag to false;
        else if (isInvincible)
        {
            isInvincible = false;
        }

        Recover();
        
    }

    public void IncreaseExperience (int amount)
    {
        experience += amount;
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if( experience >= experienceCap)
        {
            level ++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease =  range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage (float dmg)
    {
        //If the player is not currently invincible, reduce health and start invencibility

        if(!isInvincible)
        {        
            currentHealth -=  dmg;

            invincibilityTimer = invincibiltyDuration;
            isInvincible = true;
            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }
    public void Kill()
    {
        Debug.Log("Foi de vasco!");
    }

    public void RestoreHealth(float amount)
    {
        //Only heal the player if their current health is less than their maximun health
        if(currentHealth < currentMaxHealth)
        {
            currentHealth += amount;

            //Maker sure the player's health doesn't exceed their maximun health.
            if (currentHealth > currentMaxHealth)
            {
                currentHealth = currentMaxHealth;
            }


        }
    }

    void Recover()
    {
        if(currentHealth <= currentMaxHealth)
        {
            currentHealth += currentHpRecovery * Time.deltaTime;

            if (currentHealth > currentMaxHealth)
            {
                currentHealth = currentMaxHealth;
            }
        }
        
    }
}
