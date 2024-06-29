using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
    public int targetSceneIndex;
    public GameObject optionsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EnablePlayerControl(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EnablePlayerControl(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true); // Activate options menu panel
        PauseMenuUI.SetActive(false); // Deactivate pause menu panel
    }

    public void CloseOptionsMenu()
    {
        optionsMenuUI.SetActive(false); // Deactivate options menu panel
        PauseMenuUI.SetActive(true); // Activate pause menu panel
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }

    public void Save()
    {
        optionsMenuUI.SetActive(false);
        Resume();
    }

    void EnablePlayerControl(bool enable)
    {
        Player.GetComponent<FirstPersonController>().enabled = enable;
    }
}
