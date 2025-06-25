using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public PowerUpBase powerUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SnailController snail = other.GetComponent<SnailController>();
        if (snail && snail.heldPowerUp == null)
        {
            snail.heldPowerUp = powerUp;
            snail.ResetSpeed();
            Destroy(gameObject); // Remove pickup - expand later
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
