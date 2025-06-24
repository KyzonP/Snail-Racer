using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text speedText;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = ((player.GetComponent<SnailController>().speed + player.GetComponent<SnailController>().currentSpeedModifier)/1.5).ToString("F2");

    }
}
