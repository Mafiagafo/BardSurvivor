using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : Pickup
{
    public int healthToRestore;
    public override void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthToRestore);
    }
}
