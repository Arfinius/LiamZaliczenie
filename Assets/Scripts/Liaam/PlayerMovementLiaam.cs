using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementLiaam : MonoBehaviour
{
    public float speed;
    public float jumpVelocity;
    public float x;
    public float y;

    Rigidbody2D rb;
    Collision coll;
    PlayerAnimation anim;

    [Space]
    [Header("Booleans")]
    public bool canMove = true;

    [Space]

    private bool groundTouch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        anim = FindObjectOfType<PlayerAnimation>();
    }

    void Update()
    {

        

        //Debug.Log(x);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        if (Input.GetButtonDown("Jump"))
        {
            if (coll.onGround)
                Jump(Vector2.up, false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Shoot");
        }

        if (coll.onWall)
        {
            x = 0;
        }
    }



    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void Jump(Vector2 dir, bool wall)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpVelocity;
    }

}
