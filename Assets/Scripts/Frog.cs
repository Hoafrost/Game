using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{

    public override void Awake()
    {
        base.Awake();
        maxHealth = 50;
        health = maxHealth;
        experience = 100;
        

    }

    public override void TakeHit(float damage)
    {
        base.TakeHit(damage);
        if (health <= 0)
        {
            animator.SetTrigger("die");

        }
    }



}