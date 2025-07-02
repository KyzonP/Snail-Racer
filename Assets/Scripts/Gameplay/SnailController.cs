using UnityEngine;

public class SnailController : BaseSnail
{
    public GameObject player;


    // UI References
    public PowerUpUI powerUpUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Powerup use

        if (Input.GetKeyDown(KeyCode.E))
        {
            UsePowerUp();
        }
    }

    void Move()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (moveVec.magnitude > 1.1f)
        {
            moveVec = moveVec.normalized;
        }

        player.transform.position += moveVec * speed * currentSpeedModifier * Time.deltaTime;


    }

    public override void PickUpPowerUp(PowerUpBase newPowerUp)
    {
        base.PickUpPowerUp(newPowerUp);
        powerUpUI.UpdatePowerUpDisplay(heldPowerUp);
        
    }

    public void UsePowerUp()
    {
        if (heldPowerUp != null)
        {
            bool usedSuccessfully = heldPowerUp.Activate(this);

            if (usedSuccessfully)
            {
                heldPowerUp = null;
                powerUpUI.UpdatePowerUpDisplay(null);
            }
            else
            {
                Debug.Log("Power-up use failed, not consuming it.");
            }
        }
    }
}
