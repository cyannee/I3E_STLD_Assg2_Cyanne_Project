using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetVolume (float volume)
    {

        mixer.SetFloat("MasterVolume", volume);
        
    
    }

    public void MuteVolume(bool mute)
    {
        Debug.Log (mute);
    }
}
