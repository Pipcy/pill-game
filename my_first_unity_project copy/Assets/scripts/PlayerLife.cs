using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// added this for the reload level function

public class PlayerLife : MonoBehaviour
{
    bool dead = false; //

    
    //if player fall off, it dies
    private void Update()
    { //if y position is below 1
        if (transform.position.y < -1f && !dead) // check if dead is false, then execute 
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body")) // we don't want to just compare names like in player movement because we want more than one enemy
        {
            // Debug.Log("Death");
            GetComponent<MeshRenderer>().enabled = false; //this is the same as unchecking the mesh renderer on the right panel
            GetComponent<Rigidbody>().isKinematic = true; // check is kinematic on rigidbody 
            GetComponent<PlayerMovement>().enabled = false;// disable
            Die();
        }
    }

    void Die()// the function that defines dying
    {
        /* moved this under collision bc we don't want player to disapear when fall off cliff
        GetComponent<MeshRenderer>().enabled = false; //this is the same as unchecking the mesh renderer on the right panel
        GetComponent<Rigidbody>().isKinematic = true; // check is kinematic on rigidbody 
        GetComponent<PlayerMovement>().enabled = false;// disable */
        dead = true;
        Debug.Log("dead");

        //destroy will destroy this entire script which has the same effect but unreversable with is not ideal
        
        //ReloadLevel();
        Invoke(nameof(ReloadLevel), 1.3f); // same thing, added delay for reload
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
