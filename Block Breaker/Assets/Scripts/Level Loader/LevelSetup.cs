using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.LevelSystem
{
    public class LevelSetup : MonoBehaviour
    {
        [SerializeField] private GameObject _levelButtonPrefab; // to create level buttons
        [SerializeField] private string[] _levelsToLoad; // to load scenes. We need level names like "Level 1" "Level 2"

        [SerializeField] private Transform _grid; // to set parent of the level button

        private void Start()
        {
            CreateLevelButton();
        }
        private void CreateLevelButton()
        {
            for (int i = 0; i < _levelsToLoad.Length; i++)
            {
                GameObject newButton = Instantiate(_levelButtonPrefab);
                // send information about level text like "1" or "2" on Level Selection menu and the other parameter is about level name like "Level 1" or "Level 2"
                newButton.GetComponent<LevelButton>().SetButton((i+1).ToString(),_levelsToLoad[i]);
                newButton.transform.SetParent(_grid,false); // set parent of the level button
            }
        }
    }
}
