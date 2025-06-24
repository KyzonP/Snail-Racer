using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public TMP_Text timerText;
    private bool raceActive = false;
    private float raceTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (raceActive)
        {
            raceTime += Time.deltaTime;
            timerText.text = $"Time: {raceTime:F2}s";
        }
    }

    public void StartRace()
    {
        raceTime = 0f;
        raceActive = true;
        Debug.Log("Race started!");
    }

    public void FinishRace()
    {
        raceActive = false;
        Debug.Log("Race finished! Your time: {raceTime:F2}");
    }
}
