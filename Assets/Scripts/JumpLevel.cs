using UnityEngine;

public class JumpLevel : MonoBehaviour
{
    PlayerController PlayerController;
    CanvaPart1 canvascript;

    public GameObject[] vides;
    void Start()
    {
        PlayerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
        vides = GameObject.FindGameObjectsWithTag("Vida");
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
        PlayerController.canMove = false;
        foreach (GameObject obj in GameManager.Instance.ElementsCanvaVictoria){
        obj.SetActive(true);
    }
    PlayerController.canMove = false;
        foreach (GameObject Enemic in GameManager.Instance.EnemicsMortals){
            if(Enemic != null){
                Enemic.SetActive(false);
            }
        }
        foreach (GameObject Enemic in GameManager.Instance.EnemicsImmortals){
            if(Enemic != null){
                Enemic.SetActive(false);
            }
        }
        foreach(GameObject vida in vides){
            vida.SetActive(false);
        }
        }
    }
}
