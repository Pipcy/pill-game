/*This code allow player to stick to a moving platform when it stands on
it and move with the platform 

OnCollisionEnter - when collide - parent
OnCollisionExit - when not collide - unaparent

more on documentation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)//the word private is optional because it's default
    {
        if (collision.gameObject.name == "player")
        {
            //make player a child of the platform
            collision.gameObject.transform.SetParent(transform);//"parent it"
        }
    }

    private void OnCollisionExit(Collision collision)//the word private is optional because it's default
    {
        if (collision.gameObject.name == "player")
        {
            //make player a child of the platform
            collision.gameObject.transform.SetParent(null);//"unparent it"
        }
    }
}
