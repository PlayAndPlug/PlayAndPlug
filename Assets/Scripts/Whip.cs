using UnityEngine;

public class Whip : MonoBehaviour
{
    public GameObject original;
    public SpriteRenderer Playersprite;
    void Update()
    {
        if(original.name != "Whip"){
        if(!Playersprite.flipX){
            transform.Translate(Vector3.right * 15f * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.left * 15f * Time.deltaTime);
        }
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

