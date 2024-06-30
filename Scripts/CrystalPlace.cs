using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalPlace : MonoBehaviour
{
    public GameObject crystalPrefab;
    public Transform placePoint;
    public TextMeshProUGUI interactText; // Text to display interaction prompt
    private bool playerInRange = false;
    private bool hasCrystal = false;

    private void Start()
    {
        interactText.gameObject.SetActive(false);

        //check if player has crystal
        if (PlayerPrefs.GetInt("HasCrystal", 0) == 1)
        {
            hasCrystal = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(true);
            interactText.text = "Press [E] to place crystal";
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player presses "E" while in range
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlaceCrystal();
        }
    }

    private void PlaceCrystal()
    {
        Instantiate(crystalPrefab, placePoint.position, placePoint.rotation);

        // Hide the interaction text
        interactText.gameObject.SetActive(false);
        playerInRange = false;

        PlayerPrefs.SetInt("HasCrystal", 0);
        hasCrystal = false ;

    }
}
