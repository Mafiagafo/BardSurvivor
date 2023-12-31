﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumController : InstrumentController
{

    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void PlayAttack(){
        base.PlayAttack();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.drumPlayed, this.transform.position);
        GameObject spawnedDrum = Instantiate(instrumentData.Prefab);
        spawnedDrum.transform.position = transform.position;
        spawnedDrum.GetComponent<DrumBehaviour>().DirectionChecker(playerMovement.lastMovedVector);

    }
}
