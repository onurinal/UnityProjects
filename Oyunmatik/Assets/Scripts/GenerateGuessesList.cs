using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GenerateGuessesList : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    public void generateGuessesList()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();  // to get values from TestingQuestions script.
        string CheckingScenes = SceneManager.GetActiveScene().name;

        for (int i = 0; i < 4; i++)
        {
            TestingQuestions.temp = TestingQuestions.GuessList[i];
            TestingQuestions.randomIndex = Random.Range(0, 4);
            TestingQuestions.GuessList[i] = TestingQuestions.GuessList[TestingQuestions.randomIndex];
            TestingQuestions.GuessList[TestingQuestions.randomIndex] = TestingQuestions.temp;
            /*This function to not coming the real result at first choice in the screen. So i created GuessList for choices
             * It mix the choices in list.
            */
        }
        if ((CheckingScenes == "HardAddition" || CheckingScenes == "HardSubtraction" || CheckingScenes == "HardMultiplication" || CheckingScenes == "HardMixed" || CheckingScenes == "Hard10Seconds" || CheckingScenes == "HardMathDuel") && TestingQuestions.CheckFunctionNumber != 5)
        {
            for (int j = 0; j < 17; j++)
            {
                if (j == 0)
                {
                    TestingQuestions.SpecialList[j] = TestingQuestions.result - 10;
                }
                else if (j <= 7)
                {
                    TestingQuestions.SpecialList[j] = TestingQuestions.SpecialList[j - 1] - 10;
                }
                else if (j == 8)
                {
                    TestingQuestions.SpecialList[j] = TestingQuestions.result + 10;
                }
                else
                {
                    TestingQuestions.SpecialList[j] = TestingQuestions.SpecialList[j - 1] + 10;
                }
                /* An idea came to my mind towards the final stages of the project. The people who will play this game can easily find the result
                 * by looking at the first digit of the number. For example 897 + 672 = ?  You can see if you sum 7 and 2 you will get 9 and then
                 * if you look the choices you will see only 1 choice has ones digit 9 like xx9. So i have to generate random numbers with the same ones digit
                 * This function only for that. That's all
                 */
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    TestingQuestions.randomResultList[i] = TestingQuestions.result;
                }
                else
                {
                    TestingQuestions.randomResult = TestingQuestions.SpecialList[Random.Range(Random.Range(0, 3), Random.Range(13, 17))];
                    for (int k = 0; k < 4; k++)
                    {
                        while (TestingQuestions.randomResultList[k] == TestingQuestions.randomResult && k < i)
                        {
                            TestingQuestions.randomResult = TestingQuestions.SpecialList[Random.Range(Random.Range(0, 3), Random.Range(13, 17))];
                            k = 0;    // to check all the numbers in list again and again.
                        }
                    }
                    TestingQuestions.randomResultList[i] = TestingQuestions.randomResult;
                }
            }
            /* I have a SpecialList which keeps the ramdom result with the same one digit. Like 20 30 40 50 60 70 ..
             */
            for (int i = 0; i < 4; i++)
            {
                TestingQuestions.Guesses[TestingQuestions.GuessList[i]].text = TestingQuestions.randomResultList[i].ToString();
                if ((CheckingScenes == "EasyMathDuel" || CheckingScenes == "MediumMathDuel" || CheckingScenes == "HardMathDuel"))
                {
                    TestingQuestions.Guesses2[TestingQuestions.GuessList[i]].text = TestingQuestions.randomResultList[i].ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    TestingQuestions.randomResultList[i] = TestingQuestions.result;
                }
                else
                {
                    TestingQuestions.randomResult = Random.Range((TestingQuestions.result - Random.Range(6, 8)), (TestingQuestions.result + Random.Range(7, 9)));
                    for (int j = 0; j < 4; j++)
                    {
                        while (TestingQuestions.randomResultList[j] == TestingQuestions.randomResult && j < i)
                        {
                            TestingQuestions.randomResult = Random.Range((TestingQuestions.result - Random.Range(6, 8)), (TestingQuestions.result + Random.Range(7, 9)));
                            j = 0;
                        }
                    }
                    TestingQuestions.randomResultList[i] = TestingQuestions.randomResult;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                TestingQuestions.Guesses[TestingQuestions.GuessList[i]].text = TestingQuestions.randomResultList[i].ToString();
                if ((CheckingScenes == "EasyMathDuel" || CheckingScenes == "MediumMathDuel" || CheckingScenes == "HardMathDuel"))
                {
                    TestingQuestions.Guesses2[TestingQuestions.GuessList[i]].text = TestingQuestions.randomResultList[i].ToString();
                }
            }
        }

        /* Why i do  ( result - Random.Range(6,8) ) or ( result + Random.Range(7,9) ) ?
         * I don't want the real result to always be the smallest or largest.
         * They must be a certain number of distances from the left and the right.
         */
    }
}