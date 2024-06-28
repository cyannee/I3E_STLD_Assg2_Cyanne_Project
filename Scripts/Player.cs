using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthText;

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
}
