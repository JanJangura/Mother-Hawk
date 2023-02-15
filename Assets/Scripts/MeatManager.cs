using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatManager : MonoBehaviour
{
    public int meatCount;
    public Text meatText;
    public int maxFireRate;

    [Header("GameObjects")]
    public GameObject enemySpawner;
    public GameObject finalBoss;
    public Transform SpawnLocation;

    [Header("Scripts")]
    public PlayerMovement PM;
    public RandomSpawner RS;

    // Start is called before the first frame update
    void Start()
    {
        meatCount = 0;
        maxFireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        meatText.text = meatCount.ToString();

        if (meatCount >= 5 && maxFireRate < 3)
        {
            meatCount = 0;
            maxFireRate++;
            PM.FireRate = PM.FireRate - .1f;
            if (PM.currentHealth < PM.maxHealth)
            {
                PM.currentHealth = PM.currentHealth + 2;
            }
            RS.minTime--;
            RS.maxTime--;
            ColorSwitch();
        }        
    }

    void ColorSwitch()
    {
        if (maxFireRate == 1)
        {
            meatText.color = Color.yellow;
        }
        else if (maxFireRate == 2)
        {
            meatText.color = Color.blue;
        }
        else if (maxFireRate == 3)
        {
            meatText.color = Color.green;           
        }      
        else
        {
            Invoke("SpawnBoss", 1);
            maxFireRate++;
        }
    }
}
