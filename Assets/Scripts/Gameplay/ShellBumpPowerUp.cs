using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewShellBump", menuName = "PowerUps/Shell Bump")]
public class ShellBumpPowerUp : PowerUpBase
{
    public float speedMultiplier = 3f;

    public override bool Activate(BaseSnail user)
    {
        user.StartCoroutine(ApplySpeed(user));

        return true;
    }

    private IEnumerator ApplySpeed(BaseSnail snail)
    {
        float originalSpeed = snail.speed;
        snail.speed *= speedMultiplier;

        // Enable bump
        snail.bump = true;

        //VFX here

        yield return new WaitForSeconds(duration);
        snail.speed = originalSpeed;
        snail.bump = false;
    }
}
