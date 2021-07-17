using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActivities : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    string CheckingScenes;
    public static bool buttonControl;

    void Awake()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        CheckingScenes = SceneManager.GetActiveScene().name;
    }

    public void disableButtons()  // to disable buttons when creating a new question
    {
        if (CheckingScenes == ("EasyMathDuel") || CheckingScenes == ("MediumMathDuel") || CheckingScenes == ("HardMathDuel"))
        {
            buttonControl = false;
            TestingQuestions.Guess1 = GameObject.Find("Guess 1-1").GetComponent<Button>();
            TestingQuestions.Guess2 = GameObject.Find("Guess 1-2").GetComponent<Button>();
            TestingQuestions.Guess3 = GameObject.Find("Guess 1-3").GetComponent<Button>();
            TestingQuestions.Guess4 = GameObject.Find("Guess 1-4").GetComponent<Button>();
            TestingQuestions.guess2to1 = GameObject.Find("Guess 2-1").GetComponent<Button>();
            TestingQuestions.guess2to2 = GameObject.Find("Guess 2-2").GetComponent<Button>();
            TestingQuestions.guess2to3 = GameObject.Find("Guess 2-3").GetComponent<Button>();
            TestingQuestions.guess2to4 = GameObject.Find("Guess 2-4").GetComponent<Button>();
            TestingQuestions.Guess1.enabled = false;
            TestingQuestions.Guess2.enabled = false;
            TestingQuestions.Guess3.enabled = false;
            TestingQuestions.Guess4.enabled = false;
            TestingQuestions.guess2to1.enabled = false;
            TestingQuestions.guess2to2.enabled = false;
            TestingQuestions.guess2to3.enabled = false;
            TestingQuestions.guess2to4.enabled = false;
            return;
        }
        TestingQuestions.Guess1 = GameObject.Find("Guess 1").GetComponent<Button>();
        TestingQuestions.Guess2 = GameObject.Find("Guess 2").GetComponent<Button>();
        TestingQuestions.Guess3 = GameObject.Find("Guess 3").GetComponent<Button>();
        TestingQuestions.Guess4 = GameObject.Find("Guess 4").GetComponent<Button>();
        TestingQuestions.PassButton = GameObject.Find("Pass Button").GetComponent<Button>();

        TestingQuestions.Guess1.enabled = false;
        TestingQuestions.Guess2.enabled = false;
        TestingQuestions.Guess3.enabled = false;
        TestingQuestions.Guess4.enabled = false;
        TestingQuestions.PassButton.enabled = false;
    }

    public void activeButtons() // to active buttons when creating a new question
    {
        if (CheckingScenes == ("EasyMathDuel") || CheckingScenes == ("MediumMathDuel") || CheckingScenes == ("HardMathDuel"))
        {
            buttonControl = true;
            TestingQuestions.Guess1 = GameObject.Find("Guess 1-1").GetComponent<Button>();
            TestingQuestions.Guess2 = GameObject.Find("Guess 1-2").GetComponent<Button>();
            TestingQuestions.Guess3 = GameObject.Find("Guess 1-3").GetComponent<Button>();
            TestingQuestions.Guess4 = GameObject.Find("Guess 1-4").GetComponent<Button>();
            TestingQuestions.guess2to1 = GameObject.Find("Guess 2-1").GetComponent<Button>();
            TestingQuestions.guess2to2 = GameObject.Find("Guess 2-2").GetComponent<Button>();
            TestingQuestions.guess2to3 = GameObject.Find("Guess 2-3").GetComponent<Button>();
            TestingQuestions.guess2to4 = GameObject.Find("Guess 2-4").GetComponent<Button>();
            TestingQuestions.Guess1.enabled = true;
            TestingQuestions.Guess2.enabled = true;
            TestingQuestions.Guess3.enabled = true;
            TestingQuestions.Guess4.enabled = true;
            TestingQuestions.guess2to1.enabled = true;
            TestingQuestions.guess2to2.enabled = true;
            TestingQuestions.guess2to3.enabled = true;
            TestingQuestions.guess2to4.enabled = true;
            return;
        }
        TestingQuestions.Guess1.enabled = true;
        TestingQuestions.Guess2.enabled = true;
        TestingQuestions.Guess3.enabled = true;
        TestingQuestions.Guess4.enabled = true;
        TestingQuestions.PassButton.enabled = true;
    }
}
