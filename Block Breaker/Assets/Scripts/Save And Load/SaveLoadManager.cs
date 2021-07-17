using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BlockBreaker.ManagerSystem;
using UnityEngine;

namespace BlockBreaker.SaveAndLoadSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        // Save all the data
        public static void SavePlayerData(DataManager newData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/PlayerData.fun", FileMode.Create);

            PlayerData playerData = new PlayerData(newData);

            formatter.Serialize(stream, playerData);
            stream.Close();
        }
        // Load all the data. If the data file exist then load that file otherwise crate a new data file.
        public static PlayerData LoadPlayerData()
        {
            if (File.Exists(Application.persistentDataPath + "/PlayerData.fun"))
            {
                Debug.Log("Data found");
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(Application.persistentDataPath + "/PlayerData.fun", FileMode.Open);

                PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return playerData;
            }
            else
            {
                Debug.LogWarning("Data not found!");
                Debug.LogWarning("New data will be created!");
         
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(Application.persistentDataPath + "/PlayerData.fun", FileMode.Create);

                PlayerData playerData = new PlayerData();

                formatter.Serialize(stream, playerData);
                stream.Close();

                return playerData;
            }
        }
    }

}