using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetAnswersGuesses : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GetAnswersGuesses1 GetAnswersGuesses1;
    string CheckingScenes;

     void Awake()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GetAnswersGuesses1 = gameObject.GetComponent<GetAnswersGuesses1>();
        CheckingScenes = SceneManager.GetActiveScene().name;
    }

    public void getAnswersGuesses(int condition)
    {
         for(int i = 0; i < 4; i++)
         {
             if (condition == i)
             {
                if (TestingQuestions.Guesses[i].text == TestingQuestions.result.ToString())
                {
                    TestingQuestions.TrueOrFalse = 1;
                    Minimize1();
                }
                else
                {
                    TestingQuestions.TrueOrFalse = 0;
                    Minimize1();
                }
            }
             /* This loop is for checking true or false and this condition variable is for buttons
              * Like condition 1 - > First button
              * condition 2 - > Second button
              * condition 3 - > Third button
              * condition 4 - > Fourth button
              */
         }
    }
    public void GetAnswersGuesses2(int condition)
    {

        for (int i = 0; i < 4; i++)
        {
            if (condition == i)
            {
                if (TestingQuestions.Guesses2[i].text == TestingQuestions.result.ToString())
                {
                    TestingQuestions.TrueOrFalse = 1;
                    Minimize2();
                }
                else
                {
                    TestingQuestions.TrueOrFalse = 0;
                    Minimize2();
                }
            }
            /* This loop is for checking true or false and this condition variable is for buttons
             * Like condition 1 - > First button
             * condition 2 - > Second button
             * condition 3 - > Third button
             * condition 4 - > Fourth button
             */
        }
    }

    void Minimize1()
    {
        if (CheckingScenes == "EasyMathDuel" || CheckingScenes == "MediumMathDuel" || CheckingScenes == "HardMathDuel")
        {
            GetAnswersGuesses1.getAnswersGuesses2to1();
        }
        else
        {
            GetAnswersGuesses1.getAnswersGuesses1();
        }
    }
    void Minimize2()
    {
        if (CheckingScenes == "EasyMathDuel" || CheckingScenes == "MediumMathDuel" || CheckingScenes == "HardMathDuel")
        {
            GetAnswersGuesses1.getAnswersGuesses2to2();
        }
        else
        {
            GetAnswersGuesses1.getAnswersGuesses1();
        }
    }
}
