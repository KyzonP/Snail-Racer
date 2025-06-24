using UnityEngine;

public class RaceTrigger : MonoBehaviour
{
    public enum TriggerType { Start, Finish }
    public TriggerType triggerType;
    public RaceManager raceManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerType == TriggerType.Start)
            {
                raceManager.StartRace();
            }
            else if (triggerType == TriggerType.Finish)
            {
                raceManager.FinishRace();
            }
        }
    }
}
