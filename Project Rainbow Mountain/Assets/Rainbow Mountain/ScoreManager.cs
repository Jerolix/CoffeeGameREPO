using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int fails;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI failsText;

    void Start()
    {
        UpdateScoreText();
        UpdateMissedOrders();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        fails += amount;
        UpdateMissedOrders();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Completed Orders: " + score;
    }

    void UpdateMissedOrders()
    {
        failsText.text = "Missed Orders: " + fails;
    }
}
