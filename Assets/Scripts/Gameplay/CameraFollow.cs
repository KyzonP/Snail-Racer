using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // player transform
    public Vector3 offset;         // e.g., new Vector3(0, -3.5f, 0)
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Euler(-45, 0, 0); // lock rotation
    }
}
