using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    [System.Serializable]
    public class SaveWorker
    {
        public int Num;
        public int Level;
        public int DataID;
        public int DeskLevel;
    }
    [System.Serializable]
    public class SaveAchiv
    {
        public bool isBuy;
    }
    [System.Serializable]
    public class SaveGame
    {
        public int GameLevel;
        public double CoinsValue;
        public int SpecialCoinsValue;
        public List<SaveWorker> SaveWorkers;
        public List<SaveAchiv> SaveAchivs;
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        List<SaveWorker> saveWorkers = new List<SaveWorker>();
        foreach (var worler in allWorkers)
        {
            saveWorkers.Add(new SaveWorker()
            {
                Num = worler.Num,
                Level = worler.Level,
                DataID = worler.DataID,
                DeskLevel = worler.GetComponent<Desk>.level
            });
        }
        List<SaveAchiv> saveAchivs = new List<SaveAchiv>();
        foreach (var achiv in allAchivs)
        {
            saveAchivs.Add(new SaveAchiv()
            {
                isBuy = achiv.isBuy
            });
        }
        var gameData = new SaveGame()
        {
            GameLevel = 1,
            CoinsValue = 1,
            SpecialCoinsValue = 1,
            SaveWorkers = saveWorkers,
            SaveAchivs=saveAchivs
        };
        formatter.Serialize(stream, gameData);
        stream.Close();
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/save.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveGame gameData = (SaveGame)formatter.Deserialize(stream);
            foreach (var saveWorker in gameData.SaveWorkers)
            {
                CreateNewWorker(Num, Level, DataID, deskLevel);
            }
            LoadCoinsValue(gameData.CoinsValue, gameData.SpecialCoinsValue);
            for (int i = 0; allAchivs.Count; i++)
            {
                allAchivs[i].LoadIsBuy(gameData.SaveAchivs[i]);
            }
        }
        else
        {
            CreateBuyWorker();
        }
    }
}
