using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Animator transition;  // This variable for animations ..
    string CheckingScene;

     void Start()
    {
        CheckingScene = SceneManager.GetActiveScene().name;
        StartCoroutine(WaitHalfSecond());
    }

    TestingQuestions TestingQuestions;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSettingToMainMenu()
    {
        transition.SetTrigger("SettingsMenu");
        StartCoroutine(LoadSceneAnimation(0));
    }
    public void LoadHowToPlayToMainMenu()
    {
        transition.SetTrigger("HowToPlay");
        StartCoroutine(LoadSceneAnimation(0));
    }
    public void LoadFourOperationMenuToMainMenu()
    {
        transition.SetTrigger("FourOperationMenu");
        StartCoroutine(LoadSceneAnimation(0));
    }
    public void LoadDifficultMenuToMainMenu()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(0));
    }
    public void MainMenuToLoadFourOperations()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(1));
    }
    public void AdditionMenuToLoadFourOperations()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(1));
    }
    public void LoadAdditionMenuScene()
    {
        transition.SetTrigger("FourOperationMenu");
        StartCoroutine(LoadSceneAnimation(2));
    }
    public void EasyAdditionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(3));
    }
    public void MediumAdditionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(4));
    }
    public void HardAdditionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(5));
    }
    public void LoadASubtractionMenuScene()
    {
        transition.SetTrigger("FourOperationMenu");
        StartCoroutine(LoadSceneAnimation(6));
    }
    public void EasySubtractionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(7));
    }
    public void MediumSubtractionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(8));
    }
    public void HardSubtractionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(9));
    }
    public void LoadMultiplicationMenuScene()
    {
        transition.SetTrigger("FourOperationMenu");
        StartCoroutine(LoadSceneAnimation(10));
    }
    public void EasyMultiplicationScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(11));
    }
    public void MediumMultiplicationScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(12));
    }
    public void HardMultiplicationScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(13));
    }
    public void LoadDivisionMenuScene()
    {
        transition.SetTrigger("FourOperationMenu");
        StartCoroutine(LoadSceneAnimation(14));
    }
    public void EasyDivisionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(15));
    }
    public void MediumDivisionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(16));
    }
    public void HardDivisionScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(17));
    }
    public void LoadMixedMenuScene()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(18));
    }
    public void EasyMixedScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(19));
    }
    public void MediumMixedScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(20));
    }
    public void HardMixedScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(21));
    }
    public void Load10SecondsMenuScene()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(22));
    }
    public void Easy10SecondsScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(23));
    }
    public void Medium10SecondsScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(24));
    }
    public void Hard10SecondsScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(25));
    }
    public void SettingsScene()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(26));
    }
    public void HowToPlayScene()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(27));
    }
    public void LoadMathDuelScene()
    {
        transition.SetTrigger("MainMenu");
        StartCoroutine(LoadSceneAnimation(28));
    }
    public void EasyMathDuelScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(29));
    }
    public void MediumMathDuelScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(30));
    }
    public void HardMathDuelScene()
    {
        transition.SetTrigger("DifficultMenu");
        StartCoroutine(LoadSceneAnimation(31));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneAnimation(int index)
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(index);
    }
    IEnumerator WaitHalfSecond()
    {
        yield return new WaitForSeconds(1f);
        if (CheckingScene == "MainMenu")
        {
            transition.SetTrigger("Start");
        }
        /* This function is waiting 0.5 seconds when a new scene loads
         * I need to use this because my animations take 1 seconds 
         * but i just want to wait 0.5 seconds not 1 .
         */
    }
}
