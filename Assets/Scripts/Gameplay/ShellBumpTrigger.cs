using UnityEngine;

public class ShellBumpTrigger : MonoBehaviour
{
    private BaseSnail owner;

    public void Init(BaseSnail snail)
    {
        owner = snail;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BaseSnail otherSnail = other.GetComponent<BaseSnail>();
        if (otherSnail != null && otherSnail != owner)
        {
            Debug.Log($"{owner.name} bumped {otherSnail.name}");
            otherSnail.Stun(2f); // 1 second stun
        }
    }
}
