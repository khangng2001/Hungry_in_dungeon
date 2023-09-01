using Realms.Sync;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    MongoClient.Collection<GameData> collection;

    private List<IDataPersistence> dataPersistencesObjects;
    private CloudDataHandler dataHandler;

    private string pid = string.Empty;
    private GameData myAccount;


    //--------------------------------------------------------------------------------------------------------------------------------------
    private async void Awake()
    {
        // Connect database in Mongodb for HungryInDungeon
        User user = GameObject.FindObjectOfType<ConnectMongoDb>().GetComponent<ConnectMongoDb>().user;
        var mongoDbClient = user.GetMongoClient("mongodb-atlas");
        var database = mongoDbClient.GetDatabase("HungryInDungeon");
        collection = database.GetCollection<GameData>("Player");

        pid = await FindPlayer(user.Id);
        Debug.Log("myAccount.Pid: " + myAccount.Pid);
        Debug.Log("User.id: " + user.Id);
        Debug.Log("pid: " + pid);

        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        this.dataHandler = new CloudDataHandler(user);
    }

    private async Task<string> FindPlayer(string findPid)
    {
        if (collection != null)
        {
            GameData myAccountById = await collection.FindOneAsync(new { pid = findPid });
            if (myAccountById != null)
            {
                Debug.Log("Pid: " + myAccountById.Pid);
                myAccount = myAccountById;
                return myAccountById.Pid;
            }
            else
            {
                Debug.Log("Player not found.");
            }
        }
        else
        {
            Debug.LogError("Collection is null.");
        }
        return null;
    }

    private void NewGame()
    {
        // Save new data in a new game
        myAccount = new GameData();
    }

    private async void LoadGame()
    {
        // Load any save data from a file using the data handler 
        myAccount = await dataHandler.Load(pid);

        // Push the loaded data to all other script that need it 
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(myAccount);
        }
    }

    private void SaveGame()
    {
        // Pass the data other script so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref myAccount);
        }

        // Save that data to a file using data handler
        dataHandler.Save(myAccount, pid);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
