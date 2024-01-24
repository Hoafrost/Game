using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private float nextAttackTime = 0f;
    public Transform swordPoint;
    public float swordRange = 0.5f;
    public LayerMask Enemies; 
    public float attackRate = 1.0f;
    public float damage;

    public Movement movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        damage = 40;
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (!animator.GetBool("died")) 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (movement.m_Grounded)
                    {
                        Slice();
                        nextAttackTime = Time.time + 1f / attackRate;

                    }
                }
            }
        }

    }

    public void Slice()
    {
        animator.SetTrigger("attack");
    }

    public void hit()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(swordPoint.position, swordRange, Enemies);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeHit(damage);

        }
    }

    

    private void OnDrawGizmosSelected()
    {
        if (swordPoint == null) return;

        Gizmos.DrawWireSphere(swordPoint.position, swordRange);
    }
}
