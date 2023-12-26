using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerScore;
}

public class PlayerDataManager : MonoBehaviour
{
    private List<PlayerData> playerDataList = new List<PlayerData>();

    void Start()
    {
        // Load player data from JSON
        LoadPlayerData();

        // Example: Adding new player data to the list
        AddPlayer("Player1", 100);
        AddPlayer("Player2", 150);

        // Example: Accessing and modifying player data in the list
        foreach (var player in playerDataList)
        {
            Debug.Log("Player Name: " + player.playerName);
            Debug.Log("Player Score: " + player.playerScore);
        }

        // Save all player data to JSON
        SavePlayerData();
    }

    void LoadPlayerData()
    {
        // Load player data from JSON file
        string jsonString = PlayerPrefs.GetString("PlayerData", "[]"); // Using PlayerPrefs for simplicity
        playerDataList = JsonUtility.FromJson<List<PlayerData>>(jsonString);

        // If the loaded data is null, create a new instance
        if (playerDataList == null)
        {
            playerDataList = new List<PlayerData>();
        }
    }

    void SavePlayerData()
    {
        // Convert player data list to JSON
        string jsonString = JsonUtility.ToJson(playerDataList);

        // Save player data to JSON file
        PlayerPrefs.SetString("PlayerData", jsonString); // Using PlayerPrefs for simplicity
        PlayerPrefs.Save();
    }

    public void AddPlayer(string playerName, int playerScore)
    {
        // Create a new player data instance
        PlayerData newPlayer = new PlayerData
        {
            playerName = playerName,
            playerScore = playerScore
        };

        // Add the new player data to the list
        playerDataList.Add(newPlayer);
        SavePlayerData();
    }
}