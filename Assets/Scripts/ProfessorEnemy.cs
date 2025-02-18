using System.Collections;
using UnityEngine;
public class EnemyPatrol : MonoBehaviour
{
private Rigidbody2D rb;
private SpriteRenderer spriteRenderer;
private int direction = 1;
private bool flipenemy = true;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        direction = 1;
        spriteRenderer.flipX = false;
        StartCoroutine(FlipEnemy());
    }
    
    private IEnumerator FlipEnemy(){
    while(true){
    yield return new WaitForSeconds(8f);
    flipenemy = false;
    yield return new WaitForSeconds(8f);
    flipenemy = true;
    }
}
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(2f * direction, rb.linearVelocity.y);
        
        if (flipenemy)
        {
            direction = -1;
            spriteRenderer.flipX = true;
        }
        else if (!flipenemy)
        {
            direction = 1; 
            spriteRenderer.flipX = false; 
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            GameManager.Instance.Die();
        }
    }
}