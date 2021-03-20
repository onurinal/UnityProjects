using Lean.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetAnswersGuesses1 : MonoBehaviour
{

    TestingQuestions TestingQuestions;
    RenderingQuestionAnswers RenderingQuestionAnswers;
    ButtonActivities ButtonActivities;
    string CheckingScenes;

    void Awake()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        RenderingQuestionAnswers = gameObject.GetComponent<RenderingQuestionAnswers>();
        ButtonActivities = gameObject.GetComponent<ButtonActivities>();
        CheckingScenes = SceneManager.GetActiveScene().name;
    }

    public void getAnswersGuesses1()
    {
        if (TestingQuestions.TrueOrFalse == 1)
        {
            TestingQuestions.PlayTrueSound();
            if (CheckingScenes == ("Easy10Seconds") || CheckingScenes == ("Medium10Seconds") || CheckingScenes == ("Hard10Seconds"))
            {
                TestingQuestions.TimeLeft = 11.7f; 
                /* This code adding 11 seconds for 10 Seconds mode if the player choose true choice.
                 Why 11? Because when new question is rendering it's waiting 1 second so we need to add 1 second at timeleft... */
            }
            RenderingQuestionAnswers.renderingQuestionAnswers();
            TestingQuestions.TrueCounter++;
            ButtonActivities.disableButtons();
            StartCoroutine(TestingQuestions.wait());
            /* i need to call StartCoroutine function. You can add a delay to generate a new question or what you want ..
             * I give the player a second to be ready new questions
             */
        }
        else
        {
            TestingQuestions.PlayWrongSound();
            if(PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                TestingQuestions.Answers.text = "Doğru Cevap " + TestingQuestions.result + ".";
            }
            else if(PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                TestingQuestions.Answers.text = "The correct answer was " + TestingQuestions.result + ".";
            }
            TestingQuestions.WrongCounter++;
            RenderingQuestionAnswers.renderingQuestionAnswers();
            if ((CheckingScenes == ("Easy10Seconds") || CheckingScenes == ("Medium10Seconds") || CheckingScenes == ("Hard10Seconds")) && TestingQuestions.WrongCounter != 3)
            {
                TestingQuestions.TimeLeft = 11.7f;
            }
            ButtonActivities.disableButtons();
            StartCoroutine(TestingQuestions.wait());
        }
    }

    public void getAnswersGuesses2to1()
    {
        if (TestingQuestions.TrueOrFalse == 1)
        {
            TestingQuestions.PlayTrueSound();
            RenderingQuestionAnswers.renderingQuestionAnswers();
            TestingQuestions.TrueCounter++;
            ButtonActivities.disableButtons();
            StartCoroutine(TestingQuestions.wait());
        }
        else
        {
            TestingQuestions.PlayWrongSound();
            RenderingQuestionAnswers.renderingQuestionAnswers();
            TestingQuestions.TrueCounter = TestingQuestions.TrueCounter - 1;
            TestingQuestions.TrueCounter = Mathf.Clamp(TestingQuestions.TrueCounter,0,100);
            TestingQuestions.TrueCounting.text = "" + TestingQuestions.TrueCounter;
        }
    }
    public void getAnswersGuesses2to2()
    {
        if (TestingQuestions.TrueOrFalse == 1)
        {
            TestingQuestions.PlayTrueSound();
            RenderingQuestionAnswers.RenderingQuestionAnswers2();
            TestingQuestions.trueCounter2++;
            ButtonActivities.disableButtons();
            StartCoroutine(TestingQuestions.wait());
        }
        else
        {
            TestingQuestions.PlayWrongSound();
            RenderingQuestionAnswers.RenderingQuestionAnswers2();
            TestingQuestions.trueCounter2 = TestingQuestions.trueCounter2 - 1;
            TestingQuestions.trueCounter2 = Mathf.Clamp(TestingQuestions.trueCounter2, 0, 100);
            TestingQuestions.trueCounting2.text = "" + (TestingQuestions.trueCounter2 - 1);
        }
    }
}
