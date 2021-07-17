using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker.ManagerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    private string _levelName;
    public void SetButton(string levelText, string levelName)
    {
        _levelText.text = levelText; // get information about level numbers like "1" or "2" to show level selection menu
        _levelName = levelName; // get information about level names to load scene like "Level 1" or "Level 2"
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelName);
    }
}
