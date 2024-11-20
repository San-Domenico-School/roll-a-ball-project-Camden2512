using System.Collections;
using UnityEngine;
using TMPro; // Required if using TextMeshPro

public class WinTrigger : MonoBehaviour
{
    public TextMeshProUGUI winText; // Drag your "WinText" UI object here in the Inspector
    public float displayDuration = 5f; // Duration to show the message

    private void Start()
    {
        if (winText != null)
        {
            winText.text = ""; // Ensure the text is hidden initially
        }
        else
        {
            Debug.LogError("WinText is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for the object you want to trigger the message
        if (other.CompareTag("Player")) // Change "Player" to the appropriate tag for your object
        {
            StartCoroutine(DisplayWinMessage());
        }
    }

    private IEnumerator DisplayWinMessage()
    {
        if (winText != null)
        {
            winText.text = "You Win!";
            yield return new WaitForSeconds(displayDuration);
            winText.text = ""; // Hide the text after the duration
        }
    }
}