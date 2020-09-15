using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float slideForce;
    public GameObject myBody;
    public Rigidbody2D myRigidbody2D;
    public CapsuleCollider2D myCapsuleCollider2D;
    public PolygonCollider2D myPolygonCollider2D;
    public Animator myAnimator;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myPolygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void GrafityChanged()
    {
        if (myRigidbody2D.gravityScale > 0)
            myBody.transform.localScale = new Vector3(1, 1, 1);
        else if (myRigidbody2D.gravityScale < 0)
            myBody.transform.localScale = new Vector3(1, -1, 1);
    }
    public void DashEventStart()
    {
        if (myRigidbody2D.gravityScale > 0)
        {
            myBody.transform.localPosition = new Vector3(0, -0.16f, 0);
            
        }
        else
        {
            myBody.transform.localPosition = new Vector3(0, 0.16f, 0);
        }
    }
    public void DashEventEnd()
    {
        myBody.transform.localPosition = new Vector3(0, 0.031f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = false;
        }
    }
}

