using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    private string filePath;

    private static SavingSystem _instance;
    public static SavingSystem instance => _instance;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/save.data";

        if (_instance == null)
            _instance = this;

        else DestroyImmediate(this);
    }

    public void SaveGame(GameData gameData)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, gameData);
        }
    }

    public GameData LoadGame()
    {
        if (!File.Exists(filePath))
        {
            print("File does not exist");
            return null;
        }

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(fileStream) as GameData;
        }
    }
}

[System.Serializable]
public class GameData
{
    float highScore;

    string name = "Bob";

    public void SaveScore(float score)
    {
        highScore = score;
        SavingSystem.instance.SaveGame(this);
    }

    public float GetScore() => 
        highScore;
}