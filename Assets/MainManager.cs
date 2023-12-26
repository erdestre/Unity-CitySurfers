using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameInput;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI personName;
    //[SerializeField] ScoreUI scoreUI;
    string playerName;
    int score;
    public void SetPlayerName()
    {
        Debug.Log(playerName);
        playerName = playerNameInput.text;
        personName.text = playerName;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void SaveData()
    {
        GetComponent<PlayerDataManager>().AddPlayer(playerName, score);
    }
}
