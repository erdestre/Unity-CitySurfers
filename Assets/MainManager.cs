using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameInput;
    //[SerializeField] ScoreUI scoreUI;
    string playerName;
    int score;
    public void SetPlayerName()
    {
        playerName = playerNameInput.text;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void SaveData()
    {
        Debug.Log(playerName);
        Debug.Log(score);
        //scoreUI.SaveScore(playerName, score);
    }
}
