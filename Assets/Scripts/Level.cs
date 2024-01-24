using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] float experiece, maxExperience;
    public int level, points;
    [SerializeField] GameObject lvlUp;

    private void Awake()
    {
        experiece = 0;
        maxExperience = 100;
        level = 1;
        points = 0;
        

    }

    public void addExperience(float exp)
    { 
        experiece += exp;
        if (experiece >= maxExperience)
        {
            levelUp();
        }
    }

    public void levelUp()
    {
        level++;
        points++;
        lvlUp.SetActive(true);
        GetComponent<takeHit>().health = GetComponent<takeHit>().maxHealth;
        maxExperience += maxExperience * level;
 
    }
}
