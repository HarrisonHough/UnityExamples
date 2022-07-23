using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveHighScores(List<PlayerData> highScoreList)
    {
        var formatter = new BinaryFormatter();

        var path = Application.persistentDataPath + "/RSMarioScores.rsm";

        var stream = new FileStream(path, FileMode.Create);

        var data = new HighScoreData(highScoreList);
        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static HighScoreData LoadHighScores()
    {
        var path = Application.persistentDataPath + "/RSMarioScores.rsm";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var data = formatter.Deserialize(stream) as HighScoreData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return null;
        }
    }
}
