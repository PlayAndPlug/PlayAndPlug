using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WhipHolder : MonoBehaviour
{
    public GameObject prefab; 
    
    private bool cooldown = true;
    public Transform spawnPoint; 
    public float spawn;

    public GameObject player;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown(){
        while(true){
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.L)) && cooldown){
            cooldown = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(1f); 
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            yield return new WaitForSeconds(1.5f); 
            cooldown = true;   
        }
        yield return null;
    } 
    }

    void Update()
    {
        Vector3 spawn = new Vector3(spawnPoint.position.x + 2f, spawnPoint.position.y);      
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.L)) && cooldown)
        {
            Instantiate(prefab, spawn, spawnPoint.rotation);
        }
    }
}

