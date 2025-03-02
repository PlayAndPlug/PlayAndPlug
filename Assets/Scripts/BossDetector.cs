using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using TMPro;
public class BossDetector : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject bosstext;
    public GameObject paret;
    private Boss bosscript;
    public CinemachineCamera cameraPlayer;

    void Start()
    {
        bosstext.SetActive(false);
        paret.SetActive(false);
        bosscript = FindFirstObjectByType<Boss>(FindObjectsInactive.Include);
        playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BossDetector")){
            cameraPlayer.Follow = null;
            playerController.canMove = false;
            playerController.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            paret.SetActive(true);
            Destroy(collision.gameObject);    
            StartCoroutine(BossActivation());
        }
    }

    private IEnumerator BossActivation()
    {
        yield return new WaitForSeconds(1f);
        bosstext.SetActive(true);
        foreach (GameObject hp in bosscript.HPBar)
        {
            hp.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        bosscript.isActive = true;
        Destroy(bosstext);
        playerController.canMove = true;
        playerController.rb.constraints = RigidbodyConstraints2D.None;
        Destroy(gameObject);
    }
}
