using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class LoopBPM : MonoBehaviour
{
    private static LoopBPM	loopBPMInstance;

    // Game BPM Loop variables
    public float gameLoopBPM; // bpm 1 ~256
    private float beatInterval;
    private float beatIntervalD4;
    private float beatTimer;
    private float beatTimerD4;
    public static bool beatFull;
    public static bool beatD4;
    public static int beatCountFull;
    public static int beatCountD4;


    // public float secPerBeat;
    // public float songPosition;
    // public float songPositionInBeats;
    // public float dspSongTime;

    //Tap Variables
    public float[] tapTime = new float[4];
    public static int tap;
    public static bool customBeat;



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
        Tapping();
        BeatDetection();
    }

    void Tapping()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            customBeat = true;
            tap = 0;
        }
        if (customBeat)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tap < 4)
                {
                    tapTime[tap] = Time.realtimeSinceStartup;
                    tap++;
                }
                if (tap == 4)
                {
                    float avarageTime = ((tapTime[1] - tapTime[0]) + (tapTime[2] - tapTime[1]) + (tapTime[3] - tapTime[2]) / 3);
                    {
                        gameLoopBPM = (float)System.Math.Round((double)60/avarageTime, 2);
                        tap = 0;
                        beatTimer = 0;
                        beatTimerD4 = 0;
                        beatCountFull = 0;
                        beatCountD4  = 0;
                        customBeat = false;
                    }
                }
            }

        }

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
            Debug.Log("Full Beat");
        }   

        beatD4 = false;
        beatIntervalD4 = beatInterval / 4;
        beatTimerD4 += Time.deltaTime;
        if (beatTimerD4 >= beatIntervalD4)
        {
            beatTimerD4 -= beatIntervalD4;
            beatD4 = true;
            beatCountD4++;
            Debug.Log("Soft Beat");
        }


    }


}
