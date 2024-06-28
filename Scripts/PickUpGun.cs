using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpGun : MonoBehaviour
{
    public GameObject GunOnPlayer;
    public TextMeshProUGUI PickUpText;
    private bool playerInRange;

    // Start is called before the first frame update
    private void Start()
    {
        GunOnPlayer.SetActive(false); 
        PickUpText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Show the interaction text
            PickUpText.gameObject.SetActive(true);
            PickUpText.text = "Press [E] to pick up";
            playerInRange = true;
        }
    }

    /// <summary>
    /// Called when another Collider exits this object's trigger zone.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            // Hide the interaction text
            PickUpText.gameObject.SetActive(false);
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player presses "Q" while in range
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Collect the diamond
            PickUp();
        }
    }

    /// <summary>
    /// Collects the diamond by deactivating its GameObject.
    /// </summary>
    private void PickUp()
    {
        // Deactivate the diamond GameObject
        gameObject.SetActive(false);
        gameObject.SetActive(false);
        GunOnPlayer.SetActive(true );
        PickUpText.gameObject .SetActive(false);
        playerInRange = false;
    }
}
