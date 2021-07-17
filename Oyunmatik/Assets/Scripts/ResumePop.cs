using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumePop : MonoBehaviour
{
    public GameObject ResumeBackground;
    TestingQuestions testingQuestions;

    void Awake()
    {
        testingQuestions = gameObject.GetComponent<TestingQuestions>();
    }
    public void ResumeMenu()
    {
        Time.timeScale = 0;
        ResumeBackground.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ResumeBackground.SetActive(false);
    }
    public void playAgainButton()
    {
        Time.timeScale = 1;
        testingQuestions.TrueCounting.text = "0";
        testingQuestions.trueCounting2.text = "0";
        testingQuestions.AdditionCount = 0;
        testingQuestions.SubtractionCount = 0;
        testingQuestions.MultiplicationCount = 0;
        testingQuestions.DivisionCount = 0;
        testingQuestions.TrueCounter = 0;
        testingQuestions.trueCounter2 = 0;
        testingQuestions.duelTimeLeft = 64.7f;
        testingQuestions.duelTimeLeft2 = 64.7f;
        ResumeBackground.SetActive(false);
        if (testingQuestions.duelGameOverPanel.activeInHierarchy)
        {
            testingQuestions.duelGameOverPanel.SetActive(false);
            testingQuestions.mathDuelWinnerAnim.SetActive(false);
            testingQuestions.AnimationCanvas.SetActive(true);
        }
        else
        {
            testingQuestions.OriginalCanvas.SetActive(false);
            testingQuestions.AnimationCanvas.SetActive(true);
        }
        StartCoroutine(testingQuestions.AnimationTime());
    }
    public void LoadMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
