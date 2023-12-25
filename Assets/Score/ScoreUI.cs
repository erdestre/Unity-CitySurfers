using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager.AddScore(new Score("deneme", 6));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 35));
        scoreManager.AddScore(new Score("ayberk", 150));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 65));
        scoreManager.AddScore(new Score("ayberk", 65));


        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
