using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewGoopGrenade", menuName = "PowerUps/Goop Grenade")]
public class GoopGrenadePowerUp : PowerUpBase
{
    public Transform goopSpawnOrigin;
    public GameObject goopPrefab;
    public LayerMask groundLayer;

    public override bool Activate(SnailController user)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
        {
            Vector3 spawnPos = new Vector3(hit.point.x, hit.point.y, 0f);
            Instantiate(goopPrefab, spawnPos, Quaternion.identity);

            return true;
        }
        else
        {
            Debug.LogWarning("Raycast did not hit ground.");

            return false;
        }
    }
}
