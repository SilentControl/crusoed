using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator animator;
    public float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementSpeed = 4f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float new_x = 0.0f;
        float new_y = 0.0f;
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement != Vector2.zero)
        {
            animator.SetBool("is_walking", true);

            if (movement.x > 0.5f || movement.x < -0.5f)
            {
                animator.SetFloat("input_x", movement.x);
                animator.SetFloat("input_y", 0.0f);
                new_x = movement.x;
            }

            else
            if (movement.y > 0.5f || movement.y < -0.5f)
            {
                animator.SetFloat("input_y", movement.y);
                animator.SetFloat("input_x", 0.0f);
                new_y = movement.y;
            }
        }

        else
        {
            animator.SetBool("is_walking", false);
        }

        float x_good = new_x * movementSpeed * Time.deltaTime;
        float y_good = new_y * movementSpeed * Time.deltaTime;

        Vector2 newer = new Vector2(x_good, y_good);
        body.MovePosition(body.position + newer);
	}
}
