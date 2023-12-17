using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    [SerializeField] Image bg;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI scoreText;


    public void GameEnded(string status, int score)
    {
        bg.gameObject.SetActive(true);
        SetText(text, status);
        text.gameObject.SetActive(true);
        SetText(scoreText, score + "\nCollected");
        scoreText.gameObject.SetActive(true);
    }

    private void SetText(TextMeshProUGUI textBase, string text)
    {
        textBase.text = text;
    }
}
