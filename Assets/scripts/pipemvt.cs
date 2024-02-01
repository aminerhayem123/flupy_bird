using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 3f;
    private bool isMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MovePipe();
        }
    }

    void MovePipe()
    {
        // Move the pipe towards the player (along the X-axis)
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the pipe is out of the screen, and destroy it
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    // You can call this method to stop the pipe movement
    public void StopMoving()
    {
        isMoving = false;
    }
}
