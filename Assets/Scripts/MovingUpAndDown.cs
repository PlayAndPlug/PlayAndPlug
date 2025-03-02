using UnityEngine;

public class MovingUpAndDown : MonoBehaviour
{
    private float maxDistance = 0.5f;
    private float speed = 1f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + maxDistance * Mathf.Sin(Time.time * speed);
        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
