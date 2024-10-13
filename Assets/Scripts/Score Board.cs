using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public GameObject scoreBoard;
    public Image medal;
    public Sprite[] medals;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else
        {
            highScoreText.text = highScore.ToString("D4");
            medal.sprite = medals[1];
        }
    }
}
