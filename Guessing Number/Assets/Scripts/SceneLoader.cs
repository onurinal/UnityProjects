using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currenScenetIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenScenetIndex + 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadQuit()
    {
        Application.Quit();
    }
}
