using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{

    [SerializeField] protected float maxHealth, health = 0, experience;
    [SerializeField] protected GameObject enemy;
    [SerializeField] protected GameObject player;
    protected Rigidbody2D rigidbody;
    protected Animator animator;

    public virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public virtual void TakeHit(float damage)
    {
        health = health - damage;
    }

    public void dead()
    {
        giveExperience(experience);
        enemy.SetActive(false);
    }

    public void giveExperience(float exp)
    { 
        FindObjectOfType<Level>().addExperience(exp);
    }

}
