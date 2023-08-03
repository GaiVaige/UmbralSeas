using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;
    public float dragRate;
    Rigidbody rb;
    Vector3 moveDirection;
    public Transform orientation;

    [Header("Animation")]
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = dragRate;
        GetInput();

    }

    private void FixedUpdate()
    {
        DoMovement();
    }


    public void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
        {
            verticalInput = verticalInput * 2;
            anim.speed = 2;
        }
        else
        {
            anim.speed = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = verticalInput * .75f;
        }
    }

    public void DoMovement()
    {
        moveDirection = (orientation.forward * verticalInput);
        transform.Rotate(0, horizontalInput * turnSpeed, 0);
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
        

    }
}
