using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewSpeedBoost", menuName = "PowerUps/Speed Boost")]
public class SpeedBoostPowerUp : PowerUpBase
{
    public float speedMultiplier = 2f;

    public override bool Activate(BaseSnail user)
    {
        user.StartCoroutine(ApplySpeed(user));

        return true;
    }

    private IEnumerator ApplySpeed(BaseSnail snail)
    {
        float originalSpeed = snail.speed;
        snail.speed *= speedMultiplier;

        //VFX here

        yield return new WaitForSeconds(duration);
        snail.speed = originalSpeed;
    }
}
