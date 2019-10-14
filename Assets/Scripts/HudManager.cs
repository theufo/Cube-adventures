using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text ScoreLabel;

    private void Start()
    {
        ResetHud();
    }

    public void ResetHud()
    {
        ScoreLabel.text = "Score: " + GameManager.Instance.Score;
    }
}