using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.LevelSystem
{
    public class SceneLoader : MonoBehaviour
    {
        private int _currentSceneIndex;
        public void LoadNextScene()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_currentSceneIndex + 1);
        }
        public void LoadSameScene()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_currentSceneIndex);
        }
        public void LoadPreviousScene()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_currentSceneIndex - 1);
        }

        public void LoadLevelSelectionMenu()
        {
            SceneManager.LoadScene("Level Menu");
        }
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
        public void LoadQuit()
        {
            Application.Quit();
        }
    }
}
