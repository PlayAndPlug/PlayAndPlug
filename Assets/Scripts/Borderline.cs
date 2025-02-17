using UnityEngine;

public class Borderline : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
        Destroy(gameObject);
        }
        else{
        Destroy(collision.gameObject);
        }
    }
}
