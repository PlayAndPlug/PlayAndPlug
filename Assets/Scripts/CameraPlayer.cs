using Unity.Cinemachine;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public CinemachineCamera cameraPlayer;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Borderline")){
            cameraPlayer.Follow = null;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.up * 8f;
            Destroy(gameObject);
        }

    }
}
