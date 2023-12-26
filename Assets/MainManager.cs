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
    [SerializeField] LeaderBoard leaderBoard;
    [SerializeField] PlayerDataManager playerDataManager;
    //[SerializeField] ScoreUI scoreUI;
    string playerName;
    int score;
    public void SetPlayerName()
    {
        playerName = playerNameInput.text;
        personName.text = playerName;
    }
    public void SetScore(int scoreGain)
    {
        this.score += scoreGain;
        scoreText.text = score.ToString();
    }
    public void SaveData()
    {
        playerDataManager = GetComponent<PlayerDataManager>();
        playerDataManager.AddPlayer(playerName, score);
        leaderBoard.FillLeaderBoard(playerDataManager.GetData());

    }
}
