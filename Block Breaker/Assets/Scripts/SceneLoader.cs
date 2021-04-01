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
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void LoadQuit()
        {
            Application.Quit();
        }
    }
}
