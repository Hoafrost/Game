using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogRun : StateMachineBehaviour
{
    private Vector2 m_Velocity = Vector2.zero;
    Transform player;
    Rigidbody2D rigidbody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Frog>().checkFlip();
        float sign = player.position.x - rigidbody.position.x;
        Vector2 targetVelocity = new Vector2(-sign / Mathf.Abs(sign) * Time.fixedDeltaTime * animator.GetComponent<Frog>().speed * 10f, rigidbody.velocity.y);
        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, 0.05f);

        animator.SetBool("see", false);
        if (Vector2.Distance(player.position, rigidbody.position) <= animator.GetComponent<Frog>().seeRange)
        {
            animator.SetBool("see", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

 
}
