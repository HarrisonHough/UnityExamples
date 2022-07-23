using System;
using System.Collections.Generic;

[Serializable]
public class HighScoreData
{
    public PlayerData[] highScoreArray;

    public HighScoreData(List<PlayerData> dataList)
    {
        highScoreArray = new PlayerData[dataList.Count];
        for (var i = 0; i < dataList.Count; i++)
        {
            highScoreArray[i] = dataList[i];
        }
    }
}
