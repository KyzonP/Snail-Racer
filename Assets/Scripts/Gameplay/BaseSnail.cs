using UnityEngine;
using System.Collections;

public class BaseSnail : MonoBehaviour
{
    public float speed = 1f;
    public float originalSpeed = 1f;
    public float currentSpeedModifier = 1f;
    public bool bump = false;

    public PowerUpBase heldPowerUp;

    public bool isStunned = false;
    private float stunTimeRemaining = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalSpeed = speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void PickUpPowerUp(PowerUpBase newPowerUp)
    {
        heldPowerUp = newPowerUp;
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        speed = originalSpeed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        var terrain = other.GetComponent<TerrainArea>();
        if (terrain != null)
        {
            currentSpeedModifier = terrain.GetSpeedModifier();
            Debug.Log($"Entered terrain: {terrain.type}, speed mod = {currentSpeedModifier}");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var terrain = other.GetComponent<TerrainArea>();
        if (terrain != null)
        {
            currentSpeedModifier = 1f; // Reset to normal
            Debug.Log("Exited terrain.");
        }
    }

    public void Stun(float duration)
    {
        if (!isStunned)
            {
                StartCoroutine(StunCoroutine(duration));
            }
    }

    private IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        speed = 0f;

        // Animation/VFX etc

        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
        isStunned = false;
    }
}
