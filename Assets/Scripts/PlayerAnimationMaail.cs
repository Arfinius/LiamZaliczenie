using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMaail : MonoBehaviour
{

    private Animator anim;
    public PlayerMovement move;
    private Rigidbody2D rb;
    Collision coll;
    public ShieldController shield;
    public ManaBar manabar;
    public HpBar hpbar;
    [HideInInspector]
    public SpriteRenderer sr;
    int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    float time;
    bool alreadyDeath = false;
    public SelectItem selectItem;
    bool secondAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();

        shield.Disable();
        secondAttack = false;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time >= 1.5f)
        {
            secondAttack = false;
            time = 0;
        }
        

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

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

        if(sr.flipX) //lewo
        {

        }
        if (sr.flipX == false) //prawo
        {

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
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsFalling", false);
        }

        if (Input.GetMouseButtonDown(0) && selectItem.BowAtackActive)
        {
            anim.SetBool("PlayerShoot", true);
            move.speed = 0;
            move.jumpVelocity = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && selectItem.meleAtackActive && (manabar.mana.manaAmount >= 10))
        {
            //time = 0;
            //Debug.Log("Attack");
            anim.SetBool("PlayerAttack", true);
            move.speed = 0;
            move.jumpVelocity = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (selectItem == true) && (manabar.mana.manaAmount >= 10) && (secondAttack == true))
        {
            anim.SetBool("PlayerAttack2", true);
        }

        if (Input.GetKey(KeyCode.Mouse0) && selectItem.RegenActive && coll.onGround && !manabar.isEmptyMana)
        {
            CrouchShield();
            if (manabar.mana.manaAmount < 2)
                CrouchShieldDown();

            hpbar.HpRegen();
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CrouchShieldDown();
        }

        // If isManaEmpty = true - a signal for mana regeneration.
        if (manabar.mana.manaAmount <= 2)
        {
            manabar.isEmptyMana = true;
        }
        else if (manabar.mana.manaAmount >= 15f)
        {
            manabar.isEmptyMana = false;
        }

        if (hpbar.hp.hpAmount <= 0)
        {
            if (!alreadyDeath)
            {
                anim.SetBool("IsDeath", true);
                move.speed = 0;
                hpbar.hp.hpAmount = 1;
                move.jumpVelocity = 0;
                alreadyDeath = true;
            }
        }
    }

    public void ManaReduceAttack()
    {
        manabar.mana.manaAmount -= 10;
    }
    public void StopAttack()
    {
        anim.SetBool("PlayerAttack", false);
        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
        secondAttack = true;
    }
    public void StopAttack2()
    {
        anim.SetBool("PlayerAttack2", false);
        anim.SetBool("PlayerAttack", false);
        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
        secondAttack = false;
    }


    public void StopShoot()
    {
        anim.SetBool("PlayerShoot", false);

        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
    }

    void CrouchShield()
    {
        //Debug.Log("Crouch");
        anim.SetBool("IsCrouching", true);
        manabar.ShieldWhenS();
        shield.Enable();
        move.speed = 0;
        move.jumpVelocity = 0;
    }
    void CrouchShieldDown()
    {
        anim.SetBool("IsCrouching", false);
        shield.Disable();
        move.speed = 1.44f;
        move.jumpVelocity = 2.5f;
    }

    public void StopDeath()
    {
        if(alreadyDeath)
        anim.SetBool("IsDeath", false);
        move.speed = 0;
        hpbar.hp.hpAmount = 1;
        move.jumpVelocity = 0;
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
