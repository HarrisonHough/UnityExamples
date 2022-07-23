using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public List<PlayerData> highScoreList;
    public PlayerData[] highScoreArray;
    private const int MAX_HIGH_SCORES = 10;

    private void Start()
    {
        Initialize();
        SaveScores();
    }

    public void SaveScores()
    {
        SaveSystem.SaveHighScores(highScoreList);
    }

    public void AddNewScore(PlayerData newPlayerData)
    {
        if (newPlayerData.score <= highScoreList[highScoreList.Count - 1].score)
        {
            return;
        }

        int index = 9;
        for (int i = 0; i < highScoreList.Count; i++)
        {
            if (newPlayerData.score > highScoreList[i].score)
            {
                index = i;
                break;
            }
        }

        var newDataEntry = new PlayerData(newPlayerData.name, newPlayerData.score, newPlayerData.coins);
        highScoreList.Insert(index, newDataEntry);

        LogScores();
        Debug.Log("list count = " + highScoreList.Count);
        highScoreList.RemoveAt(highScoreList.Count - 1);
        Debug.Log("list count is NOW = " + highScoreList.Count);
        LogScores();
        SaveScores();
    }

    private void Initialize()
    {
        highScoreList = new List<PlayerData>();
        HighScoreData savedData = SaveSystem.LoadHighScores();

        if (savedData != null)
        {
            foreach (PlayerData data in savedData.highScoreArray)
            {
                highScoreList.Add(data);
            }
        }
        else
        {
            for (var i = 0; i < MAX_HIGH_SCORES; i++)
            {
                var tempData = new PlayerData();
                highScoreList.Add(tempData);
            }
        }
    }

    private void LogScores()
    {
        foreach (PlayerData t in highScoreList)
        {
            Debug.Log(t.name + " " + t.score + " " + t.coins);
        }
    }
}
