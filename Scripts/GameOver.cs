/*
 * Author: Cyanne Chiang
 * Date: 29/06/2024
 * Description: 
 * Panel that displays when player dies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// The GameObject representing the game over panel.
    /// </summary>
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    /// <summary>
    /// Initialises the game over panel to be hidden at the start of the game
    /// </summary>
    void Start()
    {
        // Ensure the Game Over panel is hidden at the start
        HideGameOverPanel();
    }

    /// <summary>
    /// Shows the game over panel, pauses the game and make the cursor visible
    /// </summary>
    public void ShowGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            Cursor.lockState = CursorLockMode.None; // Unlock cursor
            Cursor.visible = true; // Make cursor visible
        }
    }

    /// <summary>
    /// Hides the game over panel, resumes the game and hides the cursor
    /// </summary>
    public void HideGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
            Time.timeScale = 1f; // Resume the game
            Cursor.lockState = CursorLockMode.Locked; // Lock cursor (if your game requires it)
            Cursor.visible = false; // Hide cursor (if your game requires it)
        }
    }

    /// <summary>
    /// Restarts the game by reloading the current scene
    /// </summary>
    public void Retry()
    {
        HideGameOverPanel();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    /// <summary>
    /// Quits the application when called.
    /// </summary>
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit the game");
    }
}
