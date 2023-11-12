using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterScriptableObject", menuName ="ScriptableObjects/Characters") ]
public class CharacterScriptableObject : ScriptableObject
{
    // Start is called before the first frame update
   [SerializeField]
   GameObject startingInstrument;
   public GameObject StartingInstrument { get => startingInstrument; private set => startingInstrument = value; }
   
   [SerializeField]
   float maxHealth;
   public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

   [SerializeField]
   float hpRecovery;
   public float HpRecovery { get => hpRecovery; private set => hpRecovery = value; }

   [SerializeField]
   float moveSpeed;
   public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

   [SerializeField]
   float vibration;
   public float Vibration { get => vibration; private set => vibration = value; }

   [SerializeField]
   float projctileSpeed;
   public float ProjectileSpeed { get => projctileSpeed; private set => projctileSpeed = value; }

   [SerializeField]
   float bpmInterval;
   public float BpmInterval { get => bpmInterval; private set => bpmInterval = value; }

   [SerializeField]
   float magnet;
   public float Magnet { get => magnet; private set => magnet = value; }
}
