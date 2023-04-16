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

    private void OnTriggerEnter (Collider collider) {  
        if(!muteState){ //if not muted, mute it
            audioSource.mute = true;
        }
        else{ //if already muted, UN-mute it
            //audioSource.mute = false; 
        }
    }
}
