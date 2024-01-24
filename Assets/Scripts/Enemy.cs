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
    public float seeRange, speed;

    private bool m_FacingRight = true;
    public bool FacingRight
    {
        get { return m_FacingRight; }
        set { m_FacingRight = value; }
    }
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

    public void checkFlip()
    {
        if (rigidbody.velocity.x > 0 && !m_FacingRight)
        {
            flip();
        }

        else if (rigidbody.velocity.x < 0 && m_FacingRight)
        {
            flip();
        }
    }
    public void flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
