using System.Collections;
using System.Collections.Generic;
using BlockBreaker.ManagerSystem;
using UnityEngine;

namespace BlockBreaker.SaveAndLoadSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public int LevelReached;
        public int PlayingCurrentLevel;
        public List<int> LevelRanks;
        public PlayerData(DataManager dataManager)
        {
            LevelRanks = dataManager.LevelRanks;
            LevelReached = dataManager.LevelReached;
            PlayingCurrentLevel = dataManager.PlayingCurrentLevel;
        }
        
        // if there is no any data then load default data
        public PlayerData()
        {
            LevelRanks = new List<int>();
            LevelRanks.Add(0);

            LevelReached = 1;
            PlayingCurrentLevel = 1;
        }
    }
}

