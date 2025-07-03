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
        Transform bumpZone = snail.transform.Find("ShellBumpZone");
        if (bumpZone != null)
        {
            bumpZone.gameObject.SetActive(true);
            bumpZone.GetComponent<ShellBumpTrigger>().Init(snail);
        }

        //VFX here

        yield return new WaitForSeconds(duration);
        snail.speed = originalSpeed;
        if (bumpZone != null)
        {
            bumpZone.gameObject.SetActive(false);
        }
    }
}
