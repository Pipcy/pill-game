using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;//global scope
    [SerializeField] float movementSpeed = 6f; //[serializefield] makes this item adjustiable from unity inerface
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck; //episode 4
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//local
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    
    bool IsGrounded()//check if touching ground epi4
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
        //check if position overlap with "ground",o.1f is the size of feet
    }
    
    
}

