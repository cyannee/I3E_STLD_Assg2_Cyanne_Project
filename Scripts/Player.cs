using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private KeyDoor currentKeyDoor;
    public bool hasKey = false;

    /// <summary>
    /// The current health of the player
    /// </summary>
    int currentHealth = 100;

    /// <summary>
    /// Initialises the player object
    /// </summary>
    void Start()
    {
        //UpdateHealthText();
  
    }
    /// <summary>
    /// Store the current laser that the player is touching
    /// </summary>
    Lava currentLava;

    /// <summary>
    /// Decreases the player's health by the specified amount 
    /// </summary>
    public void DecreaseHealth(int healthToMinus)
    {
        currentHealth -= healthToMinus;
        // Update the score display text 
      //  UpdateHealthText();
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
      //      Die();
        }
    }


    public void UpdateKeyDoor(KeyDoor door)
    {
        currentKeyDoor = door;
    }

    void OnInteract()
    {

        // This is "null check"
        if (currentKeyDoor != null)
        {
            currentKeyDoor.OpenDoor();
            currentKeyDoor = null;
        }

    }

}
