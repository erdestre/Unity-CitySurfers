using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Import the Newtonsoft.Json namespace

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerScore;
}

public class PlayerDataManager : MonoBehaviour
{
    private List<PlayerData> playerDataList = new List<PlayerData>();
    public string filePath;

    void Start()
    {
        // Set the file path (in the persistent data path for simplicity)
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        // Load player data from JSON
        LoadPlayerData();
    }

    void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            // Read player data from file using Json.NET
            string jsonString = File.ReadAllText(filePath);
            playerDataList = JsonConvert.DeserializeObject<List<PlayerData>>(jsonString);
        }

        // If the loaded data is null, create a new instance
        if (playerDataList == null)
        {
            playerDataList = new List<PlayerData>();
        }
    }

    void SavePlayerData()
    {
        // Convert player data list to JSON using Json.NET
        string jsonString = JsonConvert.SerializeObject(playerDataList, Formatting.Indented);
        Debug.Log(jsonString);

        // Write player data to file
        File.WriteAllText(filePath, jsonString);
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

        // Save player data to file after adding a new player
        SavePlayerData();
    }

    public List<PlayerData> GetData()
    {
        return playerDataList;
    }
    public void ClearPlayerData()
    {
        // Clear the playerDataList
        playerDataList.Clear();

        // Save the cleared list to the file
        SavePlayerData();
    }
}