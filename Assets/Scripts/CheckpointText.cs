using System.Collections;
using UnityEngine;

public class CheckpointText : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Text());
    }

    private IEnumerator Text(){
    yield return new WaitForSeconds(2f); 
    Destroy(gameObject);
    }

}
