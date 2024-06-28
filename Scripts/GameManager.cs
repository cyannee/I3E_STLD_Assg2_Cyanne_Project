using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensures this instance persists across scenes
            Debug.Log("GameManager Instance created and set to persist.");
        }
        else if (Instance != null && Instance != this)
        {
            Debug.Log("Duplicate GameManager instance destroyed.");
            Destroy(gameObject);  // Destroy this instance if another instance already exists
        }
    }
}

