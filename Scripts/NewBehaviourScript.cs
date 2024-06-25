using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("MasterVolume", 1f);
    }
}
