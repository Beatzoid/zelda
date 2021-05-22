using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("The target to follow")]
    public Transform target;

    [Tooltip("How smooth the camera movement is")]
    public float smoothing;

    [Tooltip("Max position of the camera")]
    public Vector2 maxPosition;

    [Tooltip("Min position of the camera")]
    public Vector2 minPosition;

    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
