using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindInTime : MonoBehaviour
{

    bool isRewinding = false;
    bool isRecording = false;

    public float recordTime = 5f;
    public float time = 0;

    List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    public Animator anim;


    // Use this for initialization
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Z))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }


    void Rewind()
    {
        Debug.Log("Rewinding....");
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, anim.GetBool("IsFalling"), anim.GetBool("Up"), anim.GetBool("IsHolding"), anim.GetBool("PlayerAttack"), anim.GetBool("IsCrouching"), anim.GetFloat("Horizontal")));

    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}