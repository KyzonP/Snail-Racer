using UnityEngine;

public class SnailController : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;
    public float currentSpeedModifier = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (moveVec.magnitude > 1.1f)
        {
            moveVec = moveVec.normalized;
        }

        player.transform.position += moveVec * speed * currentSpeedModifier * Time.deltaTime;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var terrain = other.GetComponent<TerrainArea>();
        if (terrain != null)
        {
            currentSpeedModifier = terrain.GetSpeedModifier();
            Debug.Log($"Entered terrain: {terrain.type}, speed mod = {currentSpeedModifier}");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var terrain = other.GetComponent<TerrainArea>();
        if (terrain != null)
        {
            currentSpeedModifier = 1f; // Reset to normal
            Debug.Log("Exited terrain.");
        }
    }
}
