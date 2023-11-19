using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(StudioEventEmitter))]
public class Pickup : MonoBehaviour, ICollectible
{
    Transform player;
    
    bool attracted;

    float pullSpeed;

    private StudioEventEmitter emitter;
    void Start()
    {
        pullSpeed = 5;
        player = FindObjectOfType<PlayerMovement>().transform;
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.pickupsIdle, this.gameObject);
        emitter.Play();
    }
    private void Update()
    {
        if(attracted == true)
        {
            Debug.Log("Passou pelo collect");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, pullSpeed * Time.deltaTime);
            pullSpeed += 1f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            emitter.Stop();
            Destroy(gameObject);
        }
    }

    public virtual void Collect()
    {
        //attracted = true;
    }

    public virtual void Attract()
    {
        attracted = true;
    }
}
