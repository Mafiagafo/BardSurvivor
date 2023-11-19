using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference musicPlay { get; private set;}

    [field: Header("Instruments SFX")]
    [field: SerializeField] public EventReference drumPlayed { get; private set;}

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set;}

    [field: Header("PickUps SFX")]
    [field: SerializeField] public EventReference pickupsIdle { get; private set;}

   public static FMODEvents instance { get; private set; }

   private void Awake(){
    if (instance != null)
    {
        Debug.LogError("Found more than one FMOD Events Instance in the scene");
    }
    instance = this;
   }
}
