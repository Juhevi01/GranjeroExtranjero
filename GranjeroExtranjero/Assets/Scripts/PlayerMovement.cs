using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float gravity = 9.8f;
    public float groundY = -4.5f;

    private bool isGrounded = true;
    private float verticalVelocity = 0f;

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        
        if (!isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            transform.position += Vector3.up * verticalVelocity * Time.deltaTime;

            
            if (transform.position.y <= groundY)
            {
                transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
                isGrounded = true;
                verticalVelocity = 0f;
            }
        }
    }
}