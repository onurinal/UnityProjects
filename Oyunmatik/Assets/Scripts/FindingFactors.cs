using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindingFactors : MonoBehaviour

{
    TestingQuestions TestingQuestions;
    int temp;

    public void isPrime()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();

        for (int i = 2; i <= TestingQuestions.MaxNumberList[0]; i++)
        {
            if (TestingQuestions.MaxNumberList[0] % i == 0)
            {
                TestingQuestions.PrimeCounter++;
            }
        }
        /* This function finding the number is prime or not .
         */
    }
    public void findingFactors()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();

        string CheckingScenes = SceneManager.GetActiveScene().name;

        if (CheckingScenes.Equals("EasyDivision") || TestingQuestions.CheckFunctionNumber == 1)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                temp = TestingQuestions.MaxNumberList[0];
                if(TestingQuestions.FixedVariableFactor == 1) // for coming factor " 1 " ... it's only EasyDivisin part  For example : 5 / 1 or 7 / 1
                {
                    for (int i = 1; i <= temp; i++)
                    {
                        if (temp % i == 0)
                        {
                            TestingQuestions.FactorList[TestingQuestions.FactorCounter] = i;
                            TestingQuestions.FactorCounter++;
                        }
                    }
                    TestingQuestions.MaxNumberList[1] = TestingQuestions.FactorList[Random.Range(0, TestingQuestions.FactorCounter - 1)];
                    TestingQuestions.FactorCounter = 0;
                }
                else
                {
                    Minimize();
                    TestingQuestions.MaxNumberList[1] = TestingQuestions.FactorList[Random.Range(0, TestingQuestions.FactorCounter - 1)];
                    TestingQuestions.FactorCounter = 0;
                }
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                temp = TestingQuestions.MaxNumberList[0];
                Minimize();
                TestingQuestions.MaxNumberList[1] = TestingQuestions.FactorList[Random.Range(0, (TestingQuestions.FactorCounter - 1))];
                TestingQuestions.FactorCounter = 0;
                temp = TestingQuestions.MaxNumberList[0] / TestingQuestions.MaxNumberList[1];
                Minimize();
                TestingQuestions.MaxNumberList[2] = TestingQuestions.FactorList[Random.Range(0, (TestingQuestions.FactorCounter - 1))];
                TestingQuestions.FactorCounter = 0;
            }
        }
        else if (CheckingScenes.Equals("MediumDivision") || CheckingScenes.Equals("HardDivision") || TestingQuestions.CheckFunctionNumber == 5)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                temp = TestingQuestions.MaxNumberList[0];
                Minimize();
                TestingQuestions.MaxNumberList[1] = TestingQuestions.FactorList[Random.Range(0, (TestingQuestions.FactorCounter - 1))];
                TestingQuestions.FactorCounter = 0;
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                temp = TestingQuestions.MaxNumberList[0];
                Minimize();
                TestingQuestions.MaxNumberList[1] = TestingQuestions.FactorList[Random.Range(0, (TestingQuestions.FactorCounter - 1))];
                TestingQuestions.FactorCounter = 0;
                temp = TestingQuestions.MaxNumberList[0] / TestingQuestions.MaxNumberList[1];
                Minimize();
                TestingQuestions.MaxNumberList[2] = TestingQuestions.FactorList[Random.Range(0, (TestingQuestions.FactorCounter - 1))];
                TestingQuestions.FactorCounter = 0;
            }
        }
    }
    void Minimize()
    {
        for (int i = 2; i <= temp; i++)
        {
            if (temp % i == 0)
            {
                TestingQuestions.FactorList[TestingQuestions.FactorCounter] = i;
                TestingQuestions.FactorCounter++;
            }
            // This part is finding the factors of a number from 2 to the number itself 
        }
    }

    /*First of all i am generation a number in division part and then i am calling this script ( FindingFactor.cs)
     * for checking factors and it's prime or not. If it is prime i am generating again. If it is not prime number
     * and then i generate another number from the factors of the previous number because I don't want fractional numbers
     */
}