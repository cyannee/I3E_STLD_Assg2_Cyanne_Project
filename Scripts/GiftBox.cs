using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    [SerializeField]
    private AudioClip collectAudio;

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        Debug.Log($"GiftBox took {amount} damage.");
        health -= amount;
        Debug.Log($"GiftBox health: {health}");
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GiftBox destroyed.");
        Destroy(gameObject);
        SpawnCollectible();
    }

    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
        // Optionally, play the collect sound effect
        // AudioSource.PlayClipAtPoint(collectAudio, transform.position);
    }
}

