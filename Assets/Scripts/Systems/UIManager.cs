using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text speedText;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        speedText.text = ((player.GetComponent<SnailController>().speed * player.GetComponent<SnailController>().currentSpeedModifier)).ToString("F2");
    }
}
