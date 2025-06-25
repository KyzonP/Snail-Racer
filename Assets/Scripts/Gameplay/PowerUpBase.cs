using UnityEngine;

public abstract class PowerUpBase : ScriptableObject
{
    public string powerUpName;
    public Sprite icon;
    public float duration = 3f;

    public abstract bool Activate(SnailController user);
}
