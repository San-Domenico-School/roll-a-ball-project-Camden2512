using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // Required to load and reload scenes

public class BallCollisionRestart : MonoBehaviour
{
    // The tag of the object that will trigger the restart
    public string restartTriggerTag = "RestartTrigger";

    // This method is called when the ball collides with another object
    private void OnTriggerEnter(Collider other)

    {    
        // Check if the object the ball collided with has the "RestartTrigger" tag
        if (other.gameObject.CompareTag("RestartTrigger"))
        {
            RestartGame();  // Restart the game if the ball hits the trigger object
        }
    }

    // This method will reload the current scene
    private void RestartGame()
    {
        // Reload the current scene by its name
        SceneManager.LoadScene(0);
    }
}