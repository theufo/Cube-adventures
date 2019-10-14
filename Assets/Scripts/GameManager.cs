using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private HudManager HudManager;

    public int Score = 0;
    public int HighScore = 0;

    public int CurrentLevel = 1;
    public int HighestLevel = 2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
        {
            HudManager = FindObjectOfType<HudManager>();
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        HudManager = FindObjectOfType<HudManager>();
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        if (Score > HighScore)
            HighScore = Score;
        if(HudManager != null)
            HudManager.ResetHud();
    }

    public void ResetGame()
    {
        Score = 0;
        if (HudManager != null)
            HudManager.ResetHud();
        CurrentLevel = 1;
        SceneManager.LoadScene("Level1");
    }

    public void IncreaseLevel()
    {
        if (CurrentLevel >= HighestLevel)
            CurrentLevel = 1;            
        else
            CurrentLevel++;

        SceneManager.LoadScene("Level" + CurrentLevel);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}