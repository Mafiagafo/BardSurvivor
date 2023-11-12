using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInstrumentBehaviour : MonoBehaviour
{
    public InstrumentScriptableObject instrumentData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentBpmInterval;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = instrumentData.Damage;
        currentSpeed = instrumentData.Speed;
        currentBpmInterval = instrumentData.BpmInterval;
        currentPierce = instrumentData.Pierce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;
    }

    //Refference the script from the collided collider and deal damage using TakeDamage();
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); // Make sure to use currentDame instead of instrumentData.damage in case any damage multiplier in the future
            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }

}
