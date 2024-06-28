/*
 * Author: Cyanne Chiang
 * Date: 19/05/2024
 * Description: 
 * When collided with, will decrease the players health.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    /// <summary>
    /// The amount health minused 
    /// </summary>
    public int myHealth = 10;


    /// <summary>
    /// Called when another Collider enters this object's trigger zone.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().DecreaseHealth(myHealth);
            // run collected when collided with

        }

    }




}
