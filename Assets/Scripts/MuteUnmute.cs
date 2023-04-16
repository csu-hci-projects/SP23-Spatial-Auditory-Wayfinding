using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUnmute : MonoBehaviour
{
    bool muteState = false;
    float originalVolume;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // this function is called on the frame when something collides with this game object
    private void OnCollisionEnter (Collision collision) {  
        if(!muteState){ //if not muted, mute it
            audioSource.mute = true;
        }
        else{ //if already muted, UN-mute it
            audioSource.mute = false; 
        }
    }
}
