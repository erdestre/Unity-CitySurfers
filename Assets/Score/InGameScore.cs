using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InGameScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    void Start()
    {
        SetText(score);
    }
    public void GainScore(int score)
    {
        this.score += score;
        SetText(this.score);
    }
    void SetText(int score)
    {
        scoreText.text = score.ToString();
    }
}
