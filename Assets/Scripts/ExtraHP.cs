using UnityEngine;

public class ExtraHP : MonoBehaviour
{
    Canvascript canvascript;

    void Start()
    {
    canvascript = FindFirstObjectByType<Canvascript>(FindObjectsInactive.Include);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(GameManager.Instance.vides < 3){
                canvascript.vides[GameManager.Instance.vides].SetActive(true);   
                GameManager.Instance.vides ++;
                Destroy(gameObject);
            }
        }
    }
}
