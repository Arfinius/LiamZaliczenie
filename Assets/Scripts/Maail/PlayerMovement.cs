using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    [Header("Float")]
    public float speed;
    public float jumpVelocity;
    public float slideSpeed;
    public float wallJumpLerp;
    public float dashSpeed;
    public float attackRange = 0.5f;
    [HideInInspector]
    public float x;
    [HideInInspector]
    public float y;

    Rigidbody2D rb;
    Collision coll;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    PlayerAnimation anim;
    HpBar hpBar;
    public ManaBar manaBar;

    [Space]
    [Header("Booleans")]
    public bool canMove = true;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    private bool groundTouch;
    private bool hasDashed;
    [Space]

    public SelectItem selectItem;


    public int side = 1;

    public int attackDamage = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        anim = FindObjectOfType<PlayerAnimation>();
        hpBar = FindObjectOfType<HpBar>().GetComponent<HpBar>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        if (coll.onWall && Input.GetButton("Fire1") && canMove)
        {
            wallGrab = true;
            wallSlide = false;
        }

        if (Input.GetButtonUp("Fire1") || !coll.onWall || !canMove)
        {
            wallGrab = false;
            wallSlide = false;
        }

        if (coll.onGround && !isDashing)
        {
            wallJumped = false;
            //GetComponent<BetterJump>().enabled = true;
        }

        if (wallGrab && !isDashing)
        {
            rb.gravityScale = 0;
            if (x > .2f || x < -.2f)
                rb.velocity = new Vector2(rb.velocity.x, 0);

            float speedModifier = y > 0 ? .5f : 1;

            rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
        }
        else
        {
            rb.gravityScale = 1;
        }

        if (coll.onWall && !coll.onGround)
        {
            if (x != 0 && !wallGrab)
            {
                wallSlide = true;
                WallSlide();
            }
        }

        if (!coll.onWall || coll.onGround)
            wallSlide = false;

        if (Input.GetButtonDown("Jump"))
        {
            if (coll.onGround)
                Jump(Vector2.up, false);
            if (coll.onWall && !coll.onGround)
                WallJump();
        }

        if (Input.GetButtonDown("Fire2") && !hasDashed)
        {
            if (xRaw != 0 || yRaw != 0)
                Dash(xRaw, yRaw);
        }

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        if (wallGrab || wallSlide || !canMove)
            return;

        if (x > 0)
        {
            side = 1;
        }
        if (x < 0)
        {
            side = -1;
        }

        if (coll.onWall)
        {
            x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && selectItem.meleAtackActive)
        {
            MeleAttack();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            hpBar.HpDistraction();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            hpBar.HpAddition();
        }
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool wall)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpVelocity;
    }

    private void WallJump()
    {
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1f + wallDir / 1f), true);

        wallJumped = true;
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;
    }

    private void Dash(float x, float y)
    {
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));

        hasDashed = true;

        //anim.SetTrigger("dash");

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.velocity += dir.normalized * dashSpeed;
        StartCoroutine(DashWait());
    }



    IEnumerator DashWait()
    {
        FindObjectOfType<GhostTrail>().ShowGhost();
        StartCoroutine(GroundDash());
        DOVirtual.Float(14, 0, .8f, RigidbodyDrag);

        rb.gravityScale = 0;
        //GetComponent<BetterJump>().enabled = false;
        wallJumped = true;
        isDashing = true;

        yield return new WaitForSeconds(.3f);

        rb.gravityScale = 1;
        //GetComponent<BetterJump>().enabled = true;
        wallJumped = false;
        isDashing = false;
    }

    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        if (coll.onGround)
            hasDashed = false;
    }

    private void WallSlide()
    {
        if (!canMove) 
            return;

        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;

        rb.velocity = new Vector2(push, -slideSpeed);
    }

    void MeleAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
