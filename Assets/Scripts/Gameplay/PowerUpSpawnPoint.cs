using UnityEngine;

public class PowerUpSpawnPoint : MonoBehaviour
{
    public GameObject[] possiblePickups;
    public float respawnDelay = 5f;

    private GameObject currentPickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPickup();
    }

    public void SpawnPickup()
    {
        if (possiblePickups.Length == 0) return;

        GameObject prefabToSpawn = possiblePickups[Random.Range(0, possiblePickups.Length)];
        currentPickup = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        PowerUpPickup pickupComponent = currentPickup.GetComponent<PowerUpPickup>();
        if (pickupComponent != null)
        {
            pickupComponent.OnPickupCollected += HandlePickupCollected;
        }
        
    }

    private void HandlePickupCollected()
    {
        currentPickup = null;
        Invoke(nameof(SpawnPickup), respawnDelay);
    }
}
