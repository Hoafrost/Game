using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{
    private bool m_FacingRight = true ;
    public bool FacingRight
    {
        get { return m_FacingRight; }
        set { m_FacingRight = value; }
    }

    public Transform daggerPoint;
    public float daggerRange;
    public float damage;
    public LayerMask Player;

    public override void Awake()
    {
        base.Awake();
        maxHealth = 200;
        health = maxHealth;
        daggerRange = 1.3f;
        experience = 200;
        damage = 30;

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
    private void OnDrawGizmosSelected()
    {
        if (daggerPoint == null) return;

        Gizmos.DrawWireSphere(daggerPoint.position, daggerRange);
    }

    public void attack()
    {
        Collider2D player = Physics2D.OverlapCircle(daggerPoint.position, daggerRange, Player);
        if(player != null)  player.GetComponent<takeHit>().takeDamage(damage);

    }

    public override void TakeHit(float damage)
    {
        base.TakeHit(damage);
        if (health <= 0)
        {
            animator.SetBool("dead",true);
        }
    }
}
