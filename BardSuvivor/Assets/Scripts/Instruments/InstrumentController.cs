using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentController : MonoBehaviour
{
    [Header("Instrument Stats")]
    public InstrumentScriptableObject instrumentData;
    public GameObject prefab;

    public LoopBPM loopBPM;
    float currentBpm;

    protected PlayerMovement playerMovement;
    
    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentBpm = instrumentData.BpmInterval;    
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentBpm -= Time.deltaTime;
        if(currentBpm <= 0f) //Quando o bpm for 0, attack.
        {
            PlayAttack();
        }
        
    }

    protected virtual void PlayAttack()
    {
        currentBpm = instrumentData.BpmInterval;
        //currentBpm = (instrumentData.BpmInterval * (60 / loopBPM.gameLoopBPM))/4 ;
    }
}
