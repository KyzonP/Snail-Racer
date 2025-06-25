using UnityEngine;

public class PowerUpUser : MonoBehaviour
{
    public Transform goopSpawnOrigin;
    public GameObject goopPrefab;
    public LayerMask groundLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Left-click to fire
        {
            Debug.Log("Fire");
            FireGoop();
        }
    }

    public void FireGoop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
        {
            Vector3 spawnPos = new Vector3(hit.point.x, hit.point.y, goopSpawnOrigin.position.z);
            Instantiate(goopPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Raycast did not hit ground.");
        }
    }
}
