using UnityEngine;

public class CharacterJumpWithSound : MonoBehaviour
{
    public float jumpForce = 5f; // The upward force applied for the jump
    public AudioSource audioSource; // Reference to the Audio Source
    public AudioClip jumpSound; // The jump sound clip

    private Rigidbody rb;
    private bool isGrounded = true; // To ensure the character can only jump when on the ground

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing!");
        }

        // Ensure the AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the jump key (spacebar) is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an upward force to make the character jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Set isGrounded to false while jumping

        // Play the jump sound
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Allow jumping again
        }
    }
}
