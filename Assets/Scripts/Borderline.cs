using UnityEngine;

public class Borderline : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
    playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
        playerController.canMove = false;
        Destroy(gameObject);
        }
        else{
        Destroy(collision.gameObject);
        }
    }
}
