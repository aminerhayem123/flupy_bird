using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float pipeSpeed = 3f;
    public float minYPosition = -2f;
    public float maxYPosition = 2f;
    public float pipeVerticalSpacing = 2f;
    public float amplitude = 2f;
    public float frequency = 1f;

    private Camera mainCamera;
    private int score = 0;
    public Text scoreText; // Reference to the UI Text component for displaying score

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnPipes());
    }

    IEnumerator SpawnPipes()
    {
        while (true)
        {
            float newY = CalculateYPosition();
            float worldY = ConvertToViewportToWorldY(newY);

            SpawnPipe(new Vector3(transform.position.x, worldY, 0f));

            // Increment and display the score
            score++;
            UpdateScoreText();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    float CalculateYPosition()
    {
        float newY = Mathf.Sin(Time.timeSinceLevelLoad * frequency) * amplitude;
        return Mathf.Clamp(newY, minYPosition, maxYPosition);
    }

    float ConvertToViewportToWorldY(float newY)
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(0f, newY, 0f)).y;
    }

    void SpawnPipe(Vector3 position)
    {
        GameObject newPipe = Instantiate(pipePrefab, position, Quaternion.identity);
        SetPipeSpeed(newPipe);
        Destroy(newPipe, 10f);
        MoveSpawnPosition();
    }

    void SetPipeSpeed(GameObject pipe)
    {
        PipeMovement pipeMovement = pipe.GetComponent<PipeMovement>();
        if (pipeMovement != null)
        {
            pipeMovement.speed = pipeSpeed;
        }
    }

    void MoveSpawnPosition()
    {
        transform.position += Vector3.up * pipeVerticalSpacing;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            Debug.Log("Updating Score Text: " + score);
            scoreText.text = ""+score;
        }
    }
}
