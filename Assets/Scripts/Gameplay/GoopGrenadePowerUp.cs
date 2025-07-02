using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGoopGrenade", menuName = "PowerUps/Goop Grenade")]
public class GoopGrenadePowerUp : PowerUpBase
{
    public Transform goopSpawnOrigin;
    public GameObject goopPrefab;
    public LayerMask groundLayer;

    public override bool Activate(BaseSnail user)
    {
        Vector3 spawnPos = Vector3.zero;

        if (user is SnailController)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
            {
                spawnPos = new Vector3(hit.point.x, hit.point.y, 0f);

            }
            else
            {
                Debug.LogWarning("Raycast did not hit ground.");

                return false;
            }
        }
        else if (user is AISnailController aiUser)
        {
            //Find all snails except self
            BaseSnail[] allSnails = GameObject.FindObjectsOfType<BaseSnail>();
            List<BaseSnail> rivals = new List<BaseSnail>();

            foreach (var snail in allSnails)
            {
                if (snail != user) rivals.Add(snail);
            }

            if (rivals.Count == 0)
            {
                Debug.LogWarning("No rival snails found for AI goop.");
                return false;
            }
            
            // Pick random rival
            BaseSnail target = rivals[Random.Range(0, rivals.Count)];

            // Aim a bit ahead of their current position on the y axis
            spawnPos = target.transform.position + new Vector3(0f, 1.5f, 0f);

            spawnPos.z = 0f;
        }

        Instantiate(goopPrefab, spawnPos, Quaternion.identity);

        return true;

    }
}
