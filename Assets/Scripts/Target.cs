using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public float moveSpeed = 1f;
    public float moveRange = 1f;

    private Vector3 initialPosition;

    public AudioSource source;
    public AudioClip clip;

    // Event to notify when the target is destroyed
    public event System.Action OnDestroyed;

    public ScoreCount scoreManager; // Reference to the ScoreCount script

    void OnDestroy()
    {
        scoreManager.AddScore(1); // Add 1 point when this object is destroyed
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Movement logic
        float xMovement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(initialPosition.x + xMovement, transform.position.y, transform.position.z);

        // Destroy logic
        if (health <= 0)
        {
            source.PlayOneShot(clip); // Play explosion sound when target is destroyed
            OnDestroyed?.Invoke(); // Notify manager
            Destroy(gameObject);
        }
    }
}
