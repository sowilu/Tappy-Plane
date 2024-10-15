using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreBoard;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Image medal;
    public Sprite[] medals;

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var hightScore = PlayerPrefs.GetInt("HighScore", 0);
        var secondScore = PlayerPrefs.GetInt("SecondScore", 0);
        if(score > hightScore && score > secondScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetInt("SecondScore", hightScore);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else if(score > secondScore)
        {
            PlayerPrefs.SetInt("SecondScore", score);
            PlayerPrefs.Save();
            highScoreText.text = hightScore.ToString("D4");
            medal.sprite = medals[1];
        }
        else
        {
            highScoreText.text = hightScore.ToString("D4");
            medal.sprite = medals[2];
        }
    }
}
