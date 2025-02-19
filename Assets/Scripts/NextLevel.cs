using UnityEngine;
using Unity.Cinemachine;
public class NextLevel : MonoBehaviour
{
    
    public CinemachineCamera cameraPlayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Victoria")){
            cameraPlayer.Follow = null;
        }
    }
}
