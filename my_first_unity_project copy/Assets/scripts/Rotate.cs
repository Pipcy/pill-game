using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //for coins to rotate

    [SerializeField] float speedX;
    [SerializeField] float speedY; 
    [SerializeField] float speedZ;
    /* we only want the coint to rotate on the y axis, 
    however we created x and z so this script
    will be more versatile*/

    void Update()
    { /*(degree_of_rotation * axis_speed(like a coefficient) * delta time which is 1 sec)
        so this means 1 full rotation every second */
        transform.Rotate(360 * speedX * Time.deltaTime,
                         360 * speedY * Time.deltaTime,
                         360 * speedZ * Time.deltaTime);// framerate independent
    }
}
