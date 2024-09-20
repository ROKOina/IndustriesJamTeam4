using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    [HideInInspector] public RankingData rank_data;
    string json_file_path;
    string json_file_name = "Ranking.json";

    void Awake()
    {
        json_file_path = Application.dataPath + "/" + json_file_name;

        if(!File.Exists(json_file_path))
        {
            Save(rank_data);
        }

        rank_data = Load(json_file_path);
    }

    void Save(RankingData data)
    {
        string json = JsonUtility.ToJson(data);
        StreamWriter wr = new StreamWriter(json_file_path, false);
        wr.WriteLine(json);
        wr.Close();
    }

    RankingData Load(string path)
    {
        StreamReader rd = new StreamReader(path);
        string json = rd.ReadToEnd();
        rd.Close();

        return JsonUtility.FromJson<RankingData>(json);
    }

    void OnDestroy()
    {
        Save(rank_data);
    }
}
