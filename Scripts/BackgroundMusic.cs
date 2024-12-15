using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the Audio Source
    public AudioClip backgroundMusic; // Assign the background music clip

    void Start()
    {
        // Check if the Audio Source is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Ensure the background music clip is assigned
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic; // Assign the music clip to the Audio Source
            audioSource.loop = true; // Set the music to loop
            audioSource.playOnAwake = true; // Start playing automatically
            audioSource.Play(); // Play the music
        }
        else
        {
            Debug.LogError("No background music clip assigned!");
        }
    }
}
