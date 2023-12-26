using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public RowUI rowUi;

    public void FillLeaderBoard(List<PlayerData> playerDataList)
    {

        int i = 0;
        PlayerData lastPlayer = playerDataList[playerDataList.Count - 1];
        playerDataList.RemoveAt(playerDataList.Count - 1);

        playerDataList.Sort((player1, player2) => player2.playerScore.CompareTo(player1.playerScore));

        playerDataList = GetTen(playerDataList, lastPlayer);

        foreach (var player in playerDataList)
        {
            i++;
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i).ToString();
            row.name.text = player.playerName;
            row.score.text = player.playerScore.ToString();
        }
    }
    private List<PlayerData> GetTen(List<PlayerData> playerDataList, PlayerData lastPlayer)
    {
        List<PlayerData> DataList = playerDataList;
        int playerIndex = DataList.IndexOf(lastPlayer);
        if (playerIndex >= 9)
        {
            List<PlayerData> newList = new List<PlayerData>();
            for (int i = playerIndex - 1; i > playerIndex - 9; i--)
            {
                newList.Add(DataList[i]);
            }
            newList.Add(lastPlayer);
            return newList;
        }
        DataList.Add(lastPlayer);
        return DataList;
    }
}
