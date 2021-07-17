using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker.SaveAndLoadSystem;
using UnityEngine;

namespace BlockBreaker.ManagerSystem
{
    public class DataManager : MonoBehaviour
    {
        public int LevelReached;
        public int PlayingCurrentLevel;
        public List<int> LevelRanks = new List<int>();

        public static DataManager Instance;
        private void Awake()
        {
            MakeSingleton();
            
            LoadData();
        }
        // private void OnValidate()  // This function when you need to change some values in data
        // {
        //     SaveData();
        // }
        private void MakeSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        private void SaveData()
        {
            SaveLoadManager.SavePlayerData(this);
        }
        private void LoadData()
        {
            PlayerData playerData = SaveLoadManager.LoadPlayerData();
            LevelRanks = playerData.LevelRanks;
            LevelReached = playerData.LevelReached;
            PlayingCurrentLevel = playerData.PlayingCurrentLevel;

        }
        public void IncreaseReachedLevel(int currentLevel)
        {
            if (LevelReached >= currentLevel || currentLevel > LevelManager.Instance.LevelNames.Length) return;

            LevelReached = currentLevel;
            LevelRanks.Add(0);
            
            SaveData();
        }
        public void UpdateLevelRanks(int currentLevel, int newLevelRank)
        {
            if (newLevelRank > LevelRanks[currentLevel - 1])
            {
                LevelRanks[currentLevel - 1] = newLevelRank;
                SaveData();
            }
        }
        public void UpdatePlayingCurrentLevel(int currentLevel)
        {
            PlayingCurrentLevel = currentLevel;
        }
    }
}
