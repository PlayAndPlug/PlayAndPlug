using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
public TextMeshProUGUI score;

void Start(){
        UpdateText();
    }
public void UpdateText(){
    score.text = $"SCORE: {GameManager.Instance.numberScore}";
}
}
