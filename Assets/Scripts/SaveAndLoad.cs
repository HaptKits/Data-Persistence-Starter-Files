using System;
using System.IO;
using UnityEngine;

public static class SaveAndLoad
{
  public static int currentSavedHighScore;
  public static string currentNameHighScore;

  public static void SaveHighScore(String nameToSave, int score)
  {
    Debug.Log("Running");
    SaveData highScoreData = new SaveData();
    highScoreData.holdersName = nameToSave;
    highScoreData.currentHighScore = score;

    String json = JsonUtility.ToJson(highScoreData);
    File.WriteAllText(Application.persistentDataPath + "/highScores.json", json);
  }

  public static void LoadHighScore()
  {
    string filePath = Application.persistentDataPath + "/highScores.json";
    if (!File.Exists(filePath))
    {
      Debug.Log("NO SAVED HIGH SCORES");
      return;
    }

    string json = File.ReadAllText(filePath);
    SaveData data = JsonUtility.FromJson<SaveData>(json);
    currentSavedHighScore = data.currentHighScore;
    currentNameHighScore = data.holdersName;
    
  }

  [Serializable]
  class SaveData
  {
    public String holdersName;
    public int currentHighScore;
  }
}