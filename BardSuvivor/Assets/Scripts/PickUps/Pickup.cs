using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour, ICollectible
{
    Transform player;
    
    bool attracted;

    float pullSpeed;
    void Start()
    {
        pullSpeed = 5;
        player = FindObjectOfType<PlayerMovement>().transform;
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
            Destroy(gameObject);
        }
    }

    public virtual void Collect()
    {
        attracted = true;
    }

    public virtual void Attract()
    {
        attracted = true;
    }
}
