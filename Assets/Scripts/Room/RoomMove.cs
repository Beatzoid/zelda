using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    [Tooltip("How much to change the camera coordinates by when changing rooms")]
    public Vector2 cameraChange;

    [Tooltip("How much to change the player coordinates by when changing rooms")]
    public Vector3 playerChange;

    [Tooltip("Does the room change need a title card?")]
    public bool needText;

    [Tooltip("The name of the place, if needText is true")]
    public string placeName;

    [Tooltip("The actual GameObject for the text display")]
    public Text placeText;

    [Tooltip("How long to display the text for")]
    public float displayTime = 4f;

    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(showPlaceShowCo());
            }
        }
    }

    private IEnumerator showPlaceShowCo()
    {
        placeText.gameObject.SetActive(true);
        placeText.text = placeName;

        yield return new WaitForSeconds(displayTime);
        placeText.gameObject.SetActive(false);
    }

}
