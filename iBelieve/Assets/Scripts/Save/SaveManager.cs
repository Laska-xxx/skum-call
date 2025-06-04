using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static SaveManager;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private BoughtWorkers boughtWorkers;
    [SerializeField] private AllWorkersData allWorkers;
    [SerializeField] private CreateBuyWorker createBuyWorker;
    [SerializeField] private AchivController achivController;

    [System.Serializable]
    public class SaveWorker
    {
        public int Num;
        public int Level;
        public int WorkerDataID;
        public int DeskLevel;
    }
    [System.Serializable]
    public class SaveAchiv
    {
        public bool IsGet;
        public bool CanGet;
    }
    [System.Serializable]
    public class SaveGame
    {
        public int GameLevel;
        public double CoinsValue;
        public double SpecialCoinsValue;
        public List<SaveWorker> SaveWorkers;
        public List<SaveAchiv> SaveAchivs;
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        List<SaveWorker> saveWorkers = new List<SaveWorker>();
        foreach (var worler in boughtWorkers.workers)
        {
            saveWorkers.Add(new SaveWorker()
            {
                Num = worler.GetComponent<Worker>().Num,
                Level = worler.GetComponent<Worker>().Level,
                WorkerDataID = worler.GetComponent<Worker>().workerData.ID,
                DeskLevel = worler.GetComponent<Desk>().Level
            });
        }
        List<SaveAchiv> saveAchivs = new List<SaveAchiv>();
        foreach (var achiv in achivController.achievements)
        {
            saveAchivs.Add(new SaveAchiv()
            {
                IsGet = achiv.IsGet,
                CanGet = achiv.CanGet
            });
        }
        var gameData = new SaveGame()
        {
            GameLevel = 1,
            CoinsValue = coins.coins,
            SpecialCoinsValue = coins.specialCoins,
            SaveWorkers = saveWorkers,
            SaveAchivs = saveAchivs
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
            if (gameData.SaveWorkers.Count > 0 )
            {
                for (int i = 0; i < gameData.SaveWorkers.Count;i++)
                {
                    createBuyWorker.LoadWorkers(gameData.SaveWorkers[i].Num, gameData.SaveWorkers[i].Level, gameData.SaveWorkers[i].WorkerDataID, gameData.SaveWorkers[i].DeskLevel);
                    if (i == gameData.SaveWorkers.Count - 1)
                    {
                        createBuyWorker.CreateNewBuyWorker();
                    }
                }
            }
            else
            {
                createBuyWorker.CreateNewBuyWorker();
            }
            coins.LoadCoinsValue(gameData.CoinsValue, gameData.SpecialCoinsValue);
            if (gameData.SaveAchivs != null)
            {
                for (int i = 0; i < achivController.achievements.Count; i++)
                {
                    achivController.achievements[i].IsGet = gameData.SaveAchivs[i].IsGet;
                    achivController.achievements[i].CanGet = gameData.SaveAchivs[i].CanGet;
                    if (achivController.achievements[i].IsGet)
                    {
                        achivController.achievements[i].AchivHasBeenGet();
                    }
                    else if (achivController.achievements[i].CanGet)
                    {
                        achivController.achievements[i].CanGetAchiv();
                    }
                    
                }
            }
            stream.Close();
        }
        else
        {
            createBuyWorker.CreateNewBuyWorker();
            return;
        }
    }
    public void DelSave()
    {
        File.Delete(Application.persistentDataPath + "/save.fun");
    }
}
