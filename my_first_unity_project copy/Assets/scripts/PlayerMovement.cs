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
            
            Jump(); //move to its own function so Jump is more varsitle
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }


    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    //if touch enemy head, kill enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject); 
            /*kill the enemy using destroy
            because we don't care about this one enemy
            using .parent.gameObject so it kills the "Enemy" as its entirety not just the Enemy head
            */
            Jump(); //when jump on top of the enemy, it jumps.
        }
    }
    

    bool IsGrounded()//check if touching ground epi4
    {
        return Physics.CheckSphere(groundCheck.position, .3f, ground); //11/18 changed from .1f to .3f for milk bottle it worked
        //check if position overlap with "ground",o.1f is the size of feet
    }
    
    
}

