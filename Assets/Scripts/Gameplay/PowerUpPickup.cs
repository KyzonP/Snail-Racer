using UnityEngine;
using System;

public class PowerUpPickup : MonoBehaviour
{
    public PowerUpBase powerUp;

    public event Action OnPickupCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SnailController snail = other.GetComponent<SnailController>();
        if (snail && snail.heldPowerUp == null)
        {
            snail.PickUpPowerUp(powerUp);

            OnPickupCollected?.Invoke(); //Notify spawn point

            Destroy(gameObject); // Remove pickup - expand later
        }
    }
}
