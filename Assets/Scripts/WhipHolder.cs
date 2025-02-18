using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WhipHolder : MonoBehaviour
{
    public GameObject prefab; 
    
    private bool cooldown = true;
    public Transform spawnPoint; 
    public float spawn;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown(){
        while(true){
        if (Input.GetKeyDown(KeyCode.A)){
            cooldown = false;
            yield return new WaitForSeconds(3f); 
            cooldown = true;   
        }
        yield return null;
    } 
    }

    void Update()
    {
        Vector3 spawn = new Vector3(spawnPoint.position.x + 2f, spawnPoint.position.y);      
        if (Input.GetKeyDown(KeyCode.A) && cooldown)
        {
            Instantiate(prefab, spawn, spawnPoint.rotation);
        }
    }
}

