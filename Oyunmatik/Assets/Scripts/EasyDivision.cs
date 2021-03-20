using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDivision : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;
    FindingFactors FindingFactors;

    public void easyDivision()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        FindingFactors = gameObject.GetComponent<FindingFactors>();
        TestingQuestions.DivisionCount++;

        if (TestingQuestions.DivisionCount < 6)
        {
            TestingQuestions.FixedVariableFactor = 1;
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 11);
            FindingFactors.findingFactors();
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.DivisionCount >= 6 && TestingQuestions.DivisionCount < 11)
        {
            TestingQuestions.FixedVariableFactor = 2;
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 21);
            FindingFactors.findingFactors();
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.DivisionCount >= 11 && TestingQuestions.DivisionCount < 21)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 31);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 21 && TestingQuestions.DivisionCount < 26)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 26 && TestingQuestions.DivisionCount < 36)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 51);
            Minimize();
        }
        else if (TestingQuestions.DivisionCount >= 36 && TestingQuestions.DivisionCount < 38)
         {
             TestingQuestions.DigitChoices = 2;
             TestingQuestions.MaxNumberList[0] = Random.Range(2, 31);
             Minimize();
         }
        else if (TestingQuestions.DivisionCount >= 38 && TestingQuestions.DivisionCount < 40)
         {
             TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
             Minimize();
         }
        if(TestingQuestions.DivisionCount == 40)
        {
            TestingQuestions.DivisionCount = 11;
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
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
        if (TestingQuestions.DivisionCount >= 11 && TestingQuestions.DivisionCount < 21)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 31);
        }
        else if (TestingQuestions.DivisionCount >= 21 && TestingQuestions.DivisionCount < 26) 
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
        }
        else if (TestingQuestions.DivisionCount >= 26 && TestingQuestions.DivisionCount < 36)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 51);
        }
        else if (TestingQuestions.DivisionCount >= 36 && TestingQuestions.DivisionCount < 38)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 31);
        }
        else if (TestingQuestions.DivisionCount >= 38 && TestingQuestions.DivisionCount < 40)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
        }
        else if(TestingQuestions.DivisionCount == 40)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 41);
        }

        /* This part is only for Minimize() function because if i don't use this part
         * i will lost the previous number data then it won't work
        */
    }
}
