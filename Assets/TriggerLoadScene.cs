using UnityEngine;
using UnityEngine.SceneManagement;  // To load new scenes

public class TriggerLoadScene : MonoBehaviour
{
    // Public variable to specify the name of the scene to load
    public string sceneName;

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
}