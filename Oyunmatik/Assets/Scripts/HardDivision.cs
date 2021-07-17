using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDivision : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;
    FindingFactors FindingFactors;

    public void hardDivision()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        FindingFactors = gameObject.GetComponent<FindingFactors>();
        TestingQuestions.DivisionCount++;

        if (TestingQuestions.DivisionCount < 16)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 301);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 16 && TestingQuestions.DivisionCount < 19)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 301);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 19 && TestingQuestions.DivisionCount < 29)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(150, 301);
            TestingQuestions.DigitChoices = 1;
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 29 && TestingQuestions.DivisionCount < 32)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(200, 301);
            TestingQuestions.DigitChoices = 2;
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 32 && TestingQuestions.DivisionCount < 42)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 42 && TestingQuestions.DivisionCount < 45)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 45 && TestingQuestions.DivisionCount < 55)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(400, 701);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 55 && TestingQuestions.DivisionCount < 64)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1001);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount == 64)
        {
            TestingQuestions.DivisionCount = 32;
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1001);
            Minimize();
        }
    }
    void Minimize()
    {
        FindingFactors.isPrime();
            while (TestingQuestions.PrimeCounter == 1)
            {
                getRandomRange();
                TestingQuestions.PrimeCounter = 0;
                FindingFactors.isPrime();
            }
        FindingFactors.findingFactors();
        TestingQuestions.PrimeCounter = 0;
        GenerateDigits.generateDigits();

        /* First of all , i created a PrimeCounter variable for finding the number is prime or not .
         * And i'm using this variable in this function. If the number is prime then PrimeCounter will "1"
         * and i am calling again the function FindingFactors.isPrime(). If the number is not prime it will continue
         * FindingFactors.findingFactors() -> this function is finding the factors of a number
         * In the end the function calling generateDigits()  -> it's generating the numbers randomly
         */
    }
    void getRandomRange()
    {
        if (TestingQuestions.DivisionCount < 16)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 301);
        }
        else if (TestingQuestions.DivisionCount >= 16 && TestingQuestions.DivisionCount < 19)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 301);
        }
        else if (TestingQuestions.DivisionCount >= 19 && TestingQuestions.DivisionCount < 29)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(150, 301);
        }
        else if (TestingQuestions.DivisionCount >= 29 && TestingQuestions.DivisionCount < 32)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(200, 501);
        }
        else if (TestingQuestions.DivisionCount >= 32 && TestingQuestions.DivisionCount < 42)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501);
        }
        else if (TestingQuestions.DivisionCount >= 42 && TestingQuestions.DivisionCount < 45)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501);
        }
        else if (TestingQuestions.DivisionCount >= 45 && TestingQuestions.DivisionCount < 55)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(400, 701);
        }
        else if (TestingQuestions.DivisionCount >= 55 && TestingQuestions.DivisionCount < 64)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1001);
        }
        else if (TestingQuestions.DivisionCount == 64)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1001);
        }

        /* This part is only for Minimize() function because if i don't use this part
         * i will lost the previous number data then it won't work
        */
    }
}