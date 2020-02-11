using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public HpBar hpbar;
    public SpriteRenderer SpRe;
    public Transform Player;
    public Transform Skeleton;
    public Animator anim;
    public int maxHealth = 100;
    int currentHealt;
    bool isAlive;
    private void Start()
    {
        currentHealt = maxHealth;
        isAlive = false;
        anim.SetBool("FirstStance", true);
    }

    void Update()
    {

        Debug.Log(isAlive);
        if(Vector2.Distance(Player.position, Skeleton.position) < 1f)
        {
            anim.SetBool("isAlive", true);
        }

        if (isAlive)
        {
            if (Vector2.Distance(Player.position, Skeleton.position) > 0.35f)
            {
                anim.SetBool("isAttack", false);
                anim.SetBool("isRunning", true);
            }
            if (Vector2.Distance(Player.position, Skeleton.position) <= 0.35f)
            {
                anim.SetBool("isAttack", true);
                anim.SetBool("isRunning", false);
            }
        }

        if (Vector2.Distance(Player.position, Skeleton.position) >= 1f)
        {
            anim.SetBool("Die", true);
        }

        if (this.transform.position.x > Player.transform.position.x)
        {
            SpRe.flipX = true;
        }
        else
        {
            SpRe.flipX = false;
        }

    }

    public void SetRunning()
    {
        //anim.SetBool("isAlive", false);
        anim.SetBool("isRunning", true);
        isAlive = true;
    }

    public void IsAlive()
    {
        isAlive = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        if(currentHealt <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
    }


    public void OnCollide()
    {
        hpbar.HpDistraction();
    }

}
