using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMovementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMovementDirection = new Vector2(1, 0); // Default facing right
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update lastMovementDirection only if there is movement
        if (movement.x != 0)
        {
            lastMovementDirection.x = movement.x;
        }

        // Update animator parameters
        animator.SetFloat("hor", movement.x);
        animator.SetFloat("vert", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        // Rotate character to face the direction of the last movement
        if (lastMovementDirection.x == 0 && lastMovementDirection.y==0)
        {
            transform.localScale = new Vector3(Mathf.Sign(lastMovementDirection.x), 1, 1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
