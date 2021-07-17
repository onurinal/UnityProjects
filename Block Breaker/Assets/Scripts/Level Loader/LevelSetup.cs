using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker.ManagerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace BlockBreaker.LevelSystem
{
    public class LevelSetup : MonoBehaviour
    {
        [SerializeField] private GameObject _levelButtonPrefab; // to create level button 

        [SerializeField] private Transform _grid; // to set parent of the level button

        private int _currentPage; // to change level page
        private int _currentLevel; // to get current level

        private DataManager _dataManager;
        private LevelManager _levelManager;
        private void Start()
        {
            AccessObjects();
            GetCurrentLevelPage();
            CreateLevelButton();
        }
        private void AccessObjects()
        {
            _dataManager = DataManager.Instance;
            _levelManager = LevelManager.Instance;
        }
        // For example you are playing "Level 32" after level is completed you want to go level selection menu and level selection menu
        // will show current page 3 and current level should be 25 so this method is calculating the current level and current page
        // More infos: you are playing level 8 and you clicked the level selection menu
        // The values should be like this: Current Page -> 1 and Current Level -> 1
        private void GetCurrentLevelPage()
        {
            if (_dataManager.PlayingCurrentLevel % 12 == 0)
            {
                _currentLevel = _dataManager.PlayingCurrentLevel - 12 + 1;
                _currentPage = _dataManager.PlayingCurrentLevel / 12;
            }
            else
            {
                _currentLevel = _dataManager.PlayingCurrentLevel - (_dataManager.PlayingCurrentLevel % 12 - 1);
                _currentPage = _dataManager.PlayingCurrentLevel / 12 + 1;
            }
        }
        private void CreateLevelButton()
        {
            // This loop is just creating 12 buttons for every level page and every level page can have max 12 buttons
            for (int i = _currentLevel - 1; i < _currentPage * 12; i++)
            {
                if (i >= _levelManager.LevelNames.Length) break; // if "i" index exceeds our total number of levels then break the loop
                GameObject newButton = Instantiate(_levelButtonPrefab, _grid, true);
                if (_dataManager.LevelReached >= i + 1)
                {
                    // send information about level text like "1" or "2" on Level Selection menu and the other parameter is about level name like "Level 1" or "Level 2"
                    newButton.GetComponent<LevelButton>().SetButton((i + 1).ToString(),_levelManager.LevelNames[i]);
                    _levelManager.UpdateLevelRank(newButton, i);
                }
                else
                {
                    newButton.GetComponent<Button>().enabled = false;
                    newButton.transform.GetChild(1).gameObject.SetActive(true); // active unlock button image
                }
            }
        }
        private void DestroyLevelButton()
        {
            for (int i = 0; i < _grid.childCount; i++)
            {
                Destroy(_grid.transform.GetChild(i).gameObject);
            }
        }
        // ----------- PREVIOUS AND NEXT PAGE LEVEL BUTTON FOR LEVEL SELECTION ------------
        public void GetNextLevelPage()
        {
            if (_currentLevel + 12 > _levelManager.LevelNames.Length) return;
            DestroyLevelButton();
            _currentLevel += 12;
            _currentPage += 1;
            CreateLevelButton();
        }

        public void GetPreviousLevelPage()
        {
            if (_currentLevel - 12 <= 0) return;
            DestroyLevelButton();
            _currentLevel -= 12;
            _currentPage -= 1;
            CreateLevelButton();
        }
    }
}
