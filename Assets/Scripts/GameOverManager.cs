
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public Text ScoreValue;
    public Text HighScoreValue;

    private void Start()
    {
        ScoreValue.text = GameManager.Instance.Score.ToString();
        HighScoreValue.text = GameManager.Instance.HighScore.ToString();
    }
    public void RestartGame () {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("Level1");
	}
}