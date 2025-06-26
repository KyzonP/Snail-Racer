using UnityEngine;

public class RaceTrigger : MonoBehaviour
{
    public enum TriggerType { Start, Finish }
    public TriggerType triggerType;
    public RaceManager raceManager;

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
