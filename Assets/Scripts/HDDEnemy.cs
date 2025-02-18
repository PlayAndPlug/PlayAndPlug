using UnityEngine;

public class HDDEnemy : MonoBehaviour
{
    private bool isActive = false;
    public Transform player;
    private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyDetector")){
            isActive = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            GameManager.Instance.PerdreVida();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(isActive){
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * 2f;
        }
    }
}
