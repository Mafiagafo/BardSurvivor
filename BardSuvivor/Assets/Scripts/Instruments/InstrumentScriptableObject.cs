using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="InstrumentScriptableObject", menuName ="ScriptableObjects/Instruments")]
public class InstrumentScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab {get => prefab; private set => prefab = value;}
    
    //Base Stats for weapon
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value;}

    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value;}
    
    [SerializeField]
    float bpmInterval;
    public float BpmInterval {get => bpmInterval; private set => bpmInterval = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

}
