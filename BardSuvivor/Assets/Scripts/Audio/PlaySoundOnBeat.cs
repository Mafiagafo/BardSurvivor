using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnBeat : MonoBehaviour
{
    public AudioManager audioManager;
    public FMODEvents fMODEvents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LoopBPM.beatD4)  
        {
            audioManager.PlayOneShot(FMODEvents.instance.percussionBase, this.transform.position);
        } 
    }
}
