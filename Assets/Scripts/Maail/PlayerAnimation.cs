using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private PlayerMovementLiaam move;
    private Rigidbody2D rb;
    float time;
    [HideInInspector]
    public SpriteRenderer sr;


    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<PlayerMovementLiaam>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);

        if (move.x == 0)
        {
            anim.SetFloat("Horizontal", 0f);
        }
        else
        {
            anim.SetFloat("Horizontal", 1f);
        }

        if (move.x > 0.1)
        {
            sr.flipX = false;
        }
        if (move.x < -0.1)
        {
            sr.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Crouch");
            //anim.SetBool("IsCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            //anim.SetBool("IsCrouching", false);
        }


        if (rb.velocity.y > 0)
        {
            anim.SetBool("Up", true);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("Up", false);
            anim.SetBool("IsFalling", true);
        }
        if(rb.velocity.y == 0)
        {
            anim.SetBool("IsFalling", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("PlayerShoot", true);
            move.speed = 0;
            move.jumpVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            time = 0;
            anim.SetBool("PlayerAttack", true);
            move.speed = 0;
            move.jumpVelocity = 0;
        }
    }

    public void StopAttack()
    {
        anim.SetBool("PlayerAttack", false);
        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
    }


    public void StopShoot()
    {
        anim.SetBool("PlayerShoot", false);
        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
    }

    /*
    void Update()
    {
        anim.SetBool("isDashing", move.isDashing);
    }

    public void SetHorizontalMovement(float x, float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
        
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }
    */
}
