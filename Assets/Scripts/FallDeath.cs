using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private GameObject[] Canva;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            GameManager.Instance.Die();
        }
        else{
        Destroy(collision.gameObject);
        }
    }
}

