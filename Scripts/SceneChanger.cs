using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    ///  The index of the scene to change to 
    /// </summary>
    public int targetSceneIndex;
    private void OnTriggerEnter(Collider other)
    {
        //Check whether it is the player that enters the area
        if (other.tag == "Player")
        {
            //Change scene here
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
