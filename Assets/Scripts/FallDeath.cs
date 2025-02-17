using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private GameObject[] Canva;

    void Awake()
    {
    Canva = GameObject.FindGameObjectsWithTag("CanvaPart1");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            foreach (GameObject obj in Canva){
            obj.SetActive(true);
        }
        }
        else{
        Destroy(collision.gameObject);
        }
    }
}

