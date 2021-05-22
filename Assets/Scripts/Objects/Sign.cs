using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [Tooltip("The dialog box GameObject")]
    public Text dialogBoxText;

    [Tooltip("The dialog box GameObject")]
    public GameObject dialogBox;

    [Tooltip("The text you want to display on the sign")]
    public string dialog;

    private bool playerInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.gameObject.activeInHierarchy)
            {
                dialogBox.gameObject.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogBoxText.text = dialog;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.gameObject.SetActive(false);
        }
    }
}
