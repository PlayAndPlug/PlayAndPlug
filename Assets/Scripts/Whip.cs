using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Whip : MonoBehaviour
{
    public GameObject original;
    void Update()
    {
        if(original.name != "Whip"){
        transform.Translate(Vector3.right * 15f * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemicMortal")){
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.CompareTag("WhipDestroyer")){
            Destroy(gameObject);
        }
    }


}

