using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class takeHit : MonoBehaviour
{
    public float health, maxHealth;
    private Animator animator;
    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
        animator = GetComponent<Animator>();
       
    }

    public void takeDamage(float damage)
    {
        health = health - damage;
       
        if (health <= 0)
        {
            animator.SetBool("died", true);
        }
        animator.SetTrigger("hit");
    }

    public void die()
    {
        Debug.Log("f");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
