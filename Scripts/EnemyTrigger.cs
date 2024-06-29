using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject[] hazardsToAppear; // Array of hazard GameObjects to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateHazards();
        }
    }

    void ActivateHazards()
    {
        foreach (GameObject hazard in hazardsToAppear)
        {
            hazard.SetActive(true); // Activate each hazard GameObject
        }
 
    }
}
