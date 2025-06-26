using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpUI : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text nameText;

    public void UpdatePowerUpDisplay(PowerUpBase powerUp)
    {
        if (powerUp != null)
        {
            iconImage.sprite = powerUp.icon;
            iconImage.enabled = true;
            nameText.text = powerUp.powerUpName;
        }
        else
        {
            iconImage.enabled = false;
            nameText.text = "";
        }
    }

    void Start()
    {
        UpdatePowerUpDisplay(null);
    }
}
