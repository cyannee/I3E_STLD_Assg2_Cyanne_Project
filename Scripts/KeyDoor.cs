using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    bool locked = false;

    public TextMeshProUGUI interactText;
    public int targetSceneIndex;

    private void Start()
    {
        //text is initially hidden
        interactText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called when another Collider enters this object's trigger zone.
    /// </summary>
    /// /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {

        //Check if the object that enters
        //the trigger has the Player tag
        if (other.gameObject.tag == "Player" && !opened)
        {
            //show interaction text
            interactText.gameObject.SetActive(true);

            //if it is the player, update the player which door its in front of
            other.gameObject.GetComponent<Player>().UpdateKeyDoor(this);
        }

    }

    /// <summary>
    /// Called when another Collider exits this object's trigger zone.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        // Check if the obejct exiting the trigger has the "Player" tag
        if (other.gameObject.tag == "Player")
        {
            //hide interaction text
            interactText.gameObject.SetActive(false);

            // If it is the player, update the player that there is no door
            other.gameObject.GetComponent<Player>().UpdateKeyDoor(null);

        }
    }

    /// <summary>
    /// Updates the door's state, check if player is in range and presses E to open the door.
    /// </summary>
    private void Update()
    {
        //check if player presses "E" and door is not opened
        if (Input.GetKeyDown(KeyCode.E) && interactText.gameObject.activeSelf && !opened)
        {
            OpenDoor();
        }
    }

    /// <summary>
    /// Handles the door opening 
    /// </summary>
    public void OpenDoor()
    {
        if (!locked && !opened)
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
           

    }

    /// <summary>
    /// Sets the lock status of the door.
    /// </summary>
    /// <param name="lockStatus">The lock status of the door</param>
    public void SetLock(bool lockStatus)
    {
        // Assign the lockStatus value to the locked bool.
        locked = lockStatus;
    }
}
