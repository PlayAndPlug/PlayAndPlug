using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreText scoreText;

    void Start()
    {
        scoreText = FindFirstObjectByType<ScoreText>(FindObjectsInactive.Include);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
        GameManager.Instance.numberScore += 10;
        scoreText.UpdateText();
        Destroy(gameObject);
        }
    }
}
