using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class LoopBPM : MonoBehaviour
{
    private static LoopBPM	loopBPMInstance;
    public float gameLoopBPM; // bpm 1 ~256
    private float beatInterval;
    private float beatTimer;
    // public float secPerBeat;
    // public float songPosition;
    // public float songPositionInBeats;
    // public float dspSongTime;
    public static bool beatFull;
    public static int beatCountFull;

    private void Awake()
    {
        if (loopBPMInstance != null && loopBPMInstance !=this)
        {
            Destroy(this.gameObject);
        }else
        {
            loopBPMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // secPerBeat = 60f / songBPM; 
        // dspSongTime = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();
    }

    void BeatDetection()
    {
        beatFull = false;
        beatInterval = 60 / gameLoopBPM;
        beatTimer += Time.deltaTime;
        if(beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            beatFull = true;
            beatCountFull++;
            Debug.Log("FullBeat");
        }       
    }


}
