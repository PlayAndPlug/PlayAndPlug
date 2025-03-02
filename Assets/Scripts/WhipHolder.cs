using System.Collections;
using UnityEngine;

public class WhipHolder : MonoBehaviour
{
    public GameObject prefab; 
    private bool cooldown = true;
    public Transform spawnPointRight; 
    public float spawnRight;
    public float spawnLeft;
    public SpriteRenderer playerSprite;
    public GameObject player;
    private PlayerController playerController;

    void Start()
    {
        StartCoroutine(Cooldown());
        playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
    }

    private IEnumerator Cooldown(){
        while(true){
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.L)) && cooldown && playerController.canMove){
            cooldown = false;
            playerController.canMove = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(1f); 
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            playerController.canMove = true;
            yield return new WaitForSeconds(1.5f); 
            cooldown = true;  
        }
        yield return null;
    } 
    }

    void Update()
    {
        Vector3 spawnRight = new Vector3(spawnPointRight.position.x + 2f, spawnPointRight.position.y);      
        Vector3 spawnLeft = new Vector3(spawnPointRight.position.x-6f + 2f, spawnPointRight.position.y);      
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.L)) && cooldown && playerController.canMove)
        {
            if (!playerSprite.flipX)
            {
                Instantiate(prefab, spawnRight, spawnPointRight.rotation);
            }
            else{
                Instantiate(prefab, spawnLeft, spawnPointRight.rotation);
            }
        }
    }
}

