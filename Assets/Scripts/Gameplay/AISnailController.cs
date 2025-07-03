using UnityEngine;
using System.Collections.Generic;

public class AISnailController : BaseSnail
{
    public Transform[] waypoints;
    public WaypointNode currentWaypoint;
    public WaypointNode targetWaypoint;

    public float reachThreshold = 0.1f;

    private Rigidbody2D rb;

    public Transform goopSpawnOrigin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetWaypoint == null && currentWaypoint != null)
        {
            ChooseNextWaypoint();
        }

        if (targetWaypoint != null)
        {
            MoveTowardWaypoint();
        }
    }

    public override void PickUpPowerUp(PowerUpBase newPowerUp)
    {
        base.PickUpPowerUp(newPowerUp);
        UsePowerUp();

    }

    private void UsePowerUp()
    {
        if (heldPowerUp != null)
        {
            bool usedSuccessfully = heldPowerUp.Activate(this);

            if (usedSuccessfully)
            {
                heldPowerUp = null;
            }
            else
            {
                Debug.Log("Power-up use failed, not consuming it.");
            }
        }
    }

    void ChooseNextWaypoint()
    {
        if (currentWaypoint.nextNodes == null || currentWaypoint.nextNodes.Count == 0)
        {
            return;
        }

        int index = Random.Range(0, currentWaypoint.nextNodes.Count);
        targetWaypoint = currentWaypoint.nextNodes[index];
    }

    // Choosing the optimal path - re-do this later on to add complexity
    void OldChooseNextWaypoint()
    {
        if (currentWaypoint.nextNodes == null || currentWaypoint.nextNodes.Count == 0)
        {
            return;
        }

        WaypointNode bestChoice = null;

        float bestDistance = Mathf.Infinity;

        // Pick closest next waypoint
        foreach (WaypointNode next in currentWaypoint.nextNodes)
        {
            float dist = Vector2.Distance(transform.position, next.transform.position);
            if (dist < bestDistance)
            {
                bestDistance = dist;
                bestChoice = next;
            }
        }

        targetWaypoint = bestChoice;
    }

    void MoveTowardWaypoint()
    {
        Vector2 direction = (targetWaypoint.transform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * currentSpeedModifier * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.transform.position) < reachThreshold)
        {
            currentWaypoint = targetWaypoint;
            targetWaypoint = null;
        }
    }
}
