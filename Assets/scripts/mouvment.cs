using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvment : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust the jump force as needed
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Apply upward force to simulate the bird jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
