using UnityEngine;
using TMPro;

public class HighScoreMainMenu : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Start(){
        score.text = $"Your Highest Score: {GameManager.Instance.HighScore}";
    }
}
