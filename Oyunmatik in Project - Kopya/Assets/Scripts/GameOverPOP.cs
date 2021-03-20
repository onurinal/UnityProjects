using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPOP : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    string CheckingScenes;
    public Animator transition;
    public TextMeshProUGUI winnerText1;
    public TextMeshProUGUI winnerText2;
    public ParticleSystem[] particles = new ParticleSystem[12];

    void Awake()
    {
        CheckingScenes = SceneManager.GetActiveScene().name;
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
    }
    public void gameOverPop()   
    {
        TestingQuestions.GameOverUI.SetActive(true);
        TestingQuestions.PlayDefeatSound();
        TestingQuestions.TrueCountingOver.text = TestingQuestions.TrueCounter.ToString();
        TestingQuestions.WrongCountingOver.text = TestingQuestions.WrongCounter.ToString();
        /* If player make 3 wrong in the game this function will call. I wanted to make a pop-up menu.
         * GameOverUI.SetActive(true); this is showing the GameOver menu. It's showing the true and false counter in the GameOver screen.
        */
    }
    public void playAgainButton()
    {
        TestingQuestions.GameOverUI.SetActive(false);
        TestingQuestions.TrueCounting.text = "0";
        TestingQuestions.WrongCounting.text = "0";
        TestingQuestions.AdditionCount = 0;
        TestingQuestions.SubtractionCount = 0;
        TestingQuestions.MultiplicationCount = 0;
        TestingQuestions.DivisionCount = 0;
        TestingQuestions.WrongCounter = 0;
        TestingQuestions.TrueCounter = 0;
        TestingQuestions.PassCounter = 0;
        if (CheckingScenes.Equals("Easy10Seconds") || CheckingScenes.Equals("Medium10Seconds") || CheckingScenes.Equals("Hard10Seconds"))
        {
            TestingQuestions.TimeLeft = 10.7f;
        }
        TestingQuestions.generateQuestions();

        /* This fucntion is reseting all the values in game if the player want to play again.
         */
    }
    public void GameOverDuel()
    {
        if (TestingQuestions.TrueCounter > TestingQuestions.trueCounter2)
        {
            TestingQuestions.OriginalCanvas.SetActive(false);
            TestingQuestions.mathDuelWinnerAnim.SetActive(true);
            transition.SetTrigger("Winner1");
            if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                winnerText1.text = "KAZANAN";
            }
            else if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                winnerText1.text = "WINNER";
            }
            TestingQuestions.PlayVictorySound();
            StartCoroutine(WaitParticleForWinner1());
            StartCoroutine(LoadWinnerAnimation());

        }
        else if(TestingQuestions.TrueCounter < TestingQuestions.trueCounter2)
        {
            TestingQuestions.OriginalCanvas.SetActive(false);
            TestingQuestions.mathDuelWinnerAnim.SetActive(true);
            transition.SetTrigger("Winner2");
            if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                winnerText2.text = "KAZANAN";
            }
            else if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                winnerText2.text = "WINNER";
            }
            TestingQuestions.PlayVictorySound();
            StartCoroutine(WaitParticleForWinner2());
            StartCoroutine(LoadWinnerAnimation());
        }
        else
        {
            TestingQuestions.OriginalCanvas.SetActive(false);
            TestingQuestions.mathDuelWinnerAnim.SetActive(true);
            transition.SetTrigger("NoWinner");
            if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                winnerText1.text = "BERABERE";
                winnerText2.text = "BERABERE";
            }
            else if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                winnerText1.text = "DRAW";
                winnerText2.text = "DRAW";
            }
            StartCoroutine(WaitParticleForWinner1());
            StartCoroutine(WaitParticleForWinner2());
            StartCoroutine(LoadWinnerAnimation());
        }
    }

    public IEnumerator LoadWinnerAnimation()
    {
        yield return new WaitForSeconds(3f);
        TestingQuestions.duelGameOverPanel.SetActive(true);
        winnerText1.text = "";
        winnerText2.text = "";
        
    }
    public IEnumerator WaitParticleForWinner1()
    {
        for (int i = 0; i < 6; i++)
        {
            particles[i].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator WaitParticleForWinner2()
    {
        for (int i = 6; i < 12; i++)
        {
            particles[i].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}