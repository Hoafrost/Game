using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{                      
    [Range(0, 0.3f)][SerializeField] private float smoothTime = 0.05f;                 
    [SerializeField] private LayerMask m_WhatIsGround;                        
    [SerializeField] private Transform m_GroundCheck;      
    public bool m_Grounded;

    private  float k_GroundedRadius = 0.2f;       
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true; 
    private Vector2 m_Velocity = Vector2.zero;
    private bool jump = false;
    private float horizontalMove = 0;
    private Animator animator;
    public float speed;


    public UnityEvent OnLandEvent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        speed = 30;


        if (OnLandEvent == null) OnLandEvent = new UnityEvent();
    }


    private void Update()
    {
        if (!animator.GetBool("died") && !Pause.isPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("jump", true);
                jump = true;

            }
        }
        else
        {
            horizontalMove = 0;
            jump = false;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

    }

    private void FixedUpdate()
    {
        
            Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded) OnLandEvent.Invoke();

                }
            }
        
    }


    public void Move(float move, bool jump)
    {
    
            Vector2 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, smoothTime);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }

            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }

            if (m_Grounded && jump)
            {
                m_Rigidbody2D.AddForce(new Vector2(0f, 700));
            }
        
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnLanding()
    {
        animator.SetBool("jump", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (m_GroundCheck == null) return;

        Gizmos.DrawWireSphere(m_GroundCheck.position, k_GroundedRadius);
    }
}