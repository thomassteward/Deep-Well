using UnityEngine;

public class TimeStopTrigger : MonoBehaviour
{
    // Reference to the UI Panel prefab
    public GameObject uiPanelPrefab;

    // Variable to store the instantiated UI panel
    private GameObject instantiatedPanel;

    // Flag to check if time is stopped
    private bool timeStopped = false;

    // Detect when the player enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger (assuming player has the "Player" tag)
        if (other.CompareTag("Player") && !timeStopped)
        {
            // Stop time
            Time.timeScale = 0f;

            // Instantiate the UI panel
            instantiatedPanel = Instantiate(uiPanelPrefab);

            // Set flag to prevent multiple instantiations
            timeStopped = true;
        }
    }

    // Optional: Detect if the player leaves the trigger and resume time
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player leaves the trigger
        if (other.CompareTag("Player"))
        {
            // Resume time
            Time.timeScale = 1f;

            // Destroy the instantiated panel if necessary
            if (instantiatedPanel != null)
            {
                Destroy(instantiatedPanel);
            }

            // Reset time stopped flag
            timeStopped = false;
        }
    }
}