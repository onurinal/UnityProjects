using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.ManagerSystem
{
    public class LevelManager : MonoBehaviour
    {
        public string[] LevelNames; // to load scenes. We need level names like "Level 1" "Level 2"
        
        public int CurrentLevel; // to manage level selection system

        private DataManager _dataManager;

        public static LevelManager Instance;
        private void Awake()
        {
            Instance = this;
            AccessDataManager(); // should be in Awake to not get errors.
        }   
        private void AccessDataManager()
        {
            _dataManager = DataManager.Instance;
        }
        public void UpdateLevelRank(GameObject button, int currentLevel)
        {
            if (_dataManager != null)
            {
                _dataManager = DataManager.Instance;
            }
            if (_dataManager.LevelRanks[currentLevel] == 3)
            {
                button.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                button.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
            }
            else if (_dataManager.LevelRanks[currentLevel] == 2)
            {
                button.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            }
            else if (_dataManager.LevelRanks[currentLevel] == 1)
            {
                button.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            }
        }
        public void GetCurrentLevel()
        {  // split the text. For example your text is "Level 1" then temp[0] -> "Level" and temp[1] will be "1"
            string[] temp = SceneManager.GetActiveScene().name.Split(' ');
            CurrentLevel = int.Parse(temp[1]);
            _dataManager.UpdatePlayingCurrentLevel(CurrentLevel);
        }
        public void PlayCurrentLevel()
        {
            SceneManager.LoadScene("Level " + _dataManager.LevelReached);
        }
        public void PlayNextLevel()
        {
            if(CurrentLevel + 1 > LevelNames.Length) return;
            SceneManager.LoadScene("Level " + (CurrentLevel + 1));
        }
    }
}
