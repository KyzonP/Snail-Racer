using UnityEngine;

public class TerrainArea : MonoBehaviour
{
    public enum TerrainType { Normal, Grass, Slime, Water, Salt }
    public TerrainType type = TerrainType.Normal;
    public float speedModifier = 1.0f;

    public TerrainType GetTerrainType => type;
    public float GetSpeedModifier() => speedModifier;
}
