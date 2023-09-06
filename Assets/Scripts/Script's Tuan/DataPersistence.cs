using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    MongoClient.Collection<GameData> collection;

    private GameData myAccount;
    private CloudDataHandler dataHandler;
    private List<IDataPersistence> dataPersistencesObjects;

    private async void Awake()
    {
        User user = GameObject.FindObjectOfType<ConnectMongoDb>().GetComponent<ConnectMongoDb>().user;
        var mongoDbClient = user.GetMongoClient("mongodb-atlas");
        var database = mongoDbClient.GetDatabase("HungryInDungeon");
        collection = database.GetCollection<GameData>("Player");

        myAccount = await FindPlayerPid(user.Id);
        Debug.Log("myAccount: " + myAccount.Pid);

        dataPersistencesObjects = FindAllDataPersistenceObjects();
    }

    private async Task<GameData> FindPlayerPid(string findPid)
    {
        try
        {
            GameData myAccount = await collection.FindOneAsync(new {pid = findPid});
            return myAccount;
        }
        catch (AppException ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }

    public void NewGame()
    {
        // Create new data for game
        myAccount = new GameData();
    }

    public async void LoadGame()
    {
        // Load any saved data from a player in mongodb
        myAccount = await dataHandler.Load(myAccount.Pid);
        
        // Push the load data to all other script that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(myAccount);
        }
    }

    public void SaveGame()
    {
        // Pass the data other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref myAccount);
        }

        // Save that data to a player in mongodb  
        dataHandler.Save(myAccount, myAccount.Pid);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
