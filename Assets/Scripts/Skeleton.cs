using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{


    public Transform daggerPoint;
    public float daggerRange;
    public float damage;
    public float attackRange;
    public LayerMask Player;

    public override void Awake()
    {
        base.Awake();
        maxHealth = 300;
        health = maxHealth;
        daggerRange = 1.3f;
        experience = 200;
        damage = 40;
        seeRange = 15;
        attackRange = 3.5f;
        speed = 10;

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
