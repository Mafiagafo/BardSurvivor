using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSpawner : MonoBehaviour
{
    [Header("Behaviour Settings")]
    public Transform currentUIBeat;
    [Range(0.5f, 4f)]
    public bool tapSpawned;

    public GameObject tapSpawn;

    public GameObject parentTapRadius;

    [Header("Beat Settings")]
    [Range (0,3)]
    public int onFullBeat;
    private int beatCountFull;
    [Range (0,3)]
    public int[] onBeatD4;

    public int beatCompass;

    // Start is called before the first frame update
    void Start()
    {
        beatCompass = 4;
        if (currentUIBeat == null)
        {
            currentUIBeat = this.transform;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckBeat();
        BeatSpawn();        
    }

    void BeatSpawn(){
        if (beatCountFull == 3 && !tapSpawned){
            tapSpawned = true;
            Debug.Log("Spawn");
            Instantiate(tapSpawn, parentTapRadius.transform);
            
        }
        if (beatCountFull == 0 && tapSpawned){
            tapSpawned = false;
        }
        
    }



    void CheckBeat()
    {
        beatCountFull = LoopBPM.beatCountFull % beatCompass;

        for (int i  = 0; i < onBeatD4.Length; i++ )
        {
            if (LoopBPM.beatD4 && beatCountFull == onFullBeat && LoopBPM.beatCountD4 % 4 == onBeatD4[i])
            {
            }
        }

    }
}
