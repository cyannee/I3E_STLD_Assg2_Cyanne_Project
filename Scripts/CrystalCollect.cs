using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalCollect : MonoBehaviour
{
    public int targetSceneIndex; // The index of the scene to load after collecting the crystal
    public TextMeshProUGUI interactText; // Text to display interaction prompt
    private bool playerInRange = false;

    private void Start()
    {
        // Ensure the interaction text is initially hidden
        interactText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(true);
            interactText.text = "Press [E] to collect crystal";
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
            CollectCrystal();
        }
    }

    private void CollectCrystal()
    {
        // Optionally, play a sound effect or animation here

        //indicate crystal is collected
        PlayerPrefs.SetInt("HasCrystal", 1);

        // Transition to the next scene
        SceneManager.LoadScene(targetSceneIndex);
    }
}
