using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /// <summary>
    /// The door that this key card unlocks
    /// </summary>
    public KeyDoor linkedDoor;

    /// <summary>
    /// Initialises the key card by unlocking the linked door
    /// </summary>
    private void Start()
    {
        //check if there is a linked door
        if (linkedDoor != null)
        {
            linkedDoor.SetLock(true);
        }
    }

    /// <summary>
    /// Handles collision events when the key card collides with player
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //tell door to unlock itslef
            linkedDoor.SetLock(false);
            Destroy(gameObject);
        }

    }
}
