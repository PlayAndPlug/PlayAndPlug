using UnityEngine;
using TMPro;

public class HighScoreMainMenu : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Start(){
        UpdateText();
    }
    public void UpdateText(){
    score.text = $"Your Highest Score: {GameManager.Instance.HighScore}";
}
}
