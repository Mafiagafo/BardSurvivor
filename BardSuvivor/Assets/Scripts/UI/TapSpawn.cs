using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSpawn : MonoBehaviour
{
    [Header("Behaviour Settings")]
    public Transform currentUIBeat;
    [Range(0.5f, 4f)]
    public float currentSize, minimunSize, defaultSize;
    public float shrinkFactor;
   
    

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
        currentSize = defaultSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSize > minimunSize)
        {
            currentSize *= shrinkFactor;
        } else
        {
            currentSize = minimunSize;
        }
        CheckBeat();
        currentUIBeat.localScale = new Vector3 (currentUIBeat.localScale.x , currentSize, currentUIBeat.localScale.z);
        
        
    }

    void Shrink()
    {
        currentSize = minimunSize;
    }

    void CheckBeat()
    {
        beatCountFull = LoopBPM.beatCountFull % beatCompass;

        for (int i  = 0; i < onBeatD4.Length; i++ )
        {
            if (LoopBPM.beatD4 && beatCountFull == onFullBeat && LoopBPM.beatCountD4 % 4 == onBeatD4[i])
            {
                Shrink();
            }
        }

    }
}
