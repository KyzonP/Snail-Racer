using UnityEngine;

public class TerrainArea : MonoBehaviour
{
    public enum TerrainType { Normal, Grass, Slime, Water, Salt }
    public TerrainType type = TerrainType.Normal;
    public float speedModifier = 1.0f;

    public TerrainType GetTerrainType => type;
    public float GetSpeedModifier() => speedModifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
