using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject bird; // Reference to your bird GameObject

    public float collisionRadius = 0.5f; // Adjust this value based on your scene

    void Start()
    {
        Time.timeScale = 1f; // Ensure the game is not paused initially
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        // Check for collisions between bird and pipes
        if (CheckCollision())
        {
            Debug.Log("Bird collided with a pipe!");
            GameOver();
        }
    }

    bool CheckCollision()
    {
        // Get all colliders within the specified radius around the bird's position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(bird.transform.position, collisionRadius);

        // Check if any of the colliders have the "Pipe" tag
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Pipe"))
            {
                return true;
            }
        }

        return false;
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Pause the game
        gameOverCanvas.SetActive(true);

        // Optionally, freeze the bird's movement using Rigidbody2D
        if (bird != null)
        {
            Rigidbody2D birdRb = bird.GetComponent<Rigidbody2D>();
            if (birdRb != null)
            {
                birdRb.velocity = Vector2.zero;
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        gameOverCanvas.SetActive(false);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
