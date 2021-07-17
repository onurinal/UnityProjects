using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.ManagerSystem
{
    public class MainMenuManager : MonoBehaviour
    {
        private DataManager _dataManager;
        void Start()
        {
            _dataManager = DataManager.Instance;
        }
        
        // METHOD FOR LEVEL SELECTION MENU SCENE
        public void GetLevelReachedPage()
        {
            _dataManager.PlayingCurrentLevel = _dataManager.LevelReached;
            SceneManager.LoadScene("Level Menu");
        }
    }
}
