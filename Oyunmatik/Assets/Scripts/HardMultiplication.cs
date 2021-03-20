using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMultiplication : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void hardMultiplication()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.MultiplicationCount++;

        if (TestingQuestions.MultiplicationCount < 3)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 50); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(1, 4);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 3 && TestingQuestions.MultiplicationCount < 5)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 50); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(1, 4); TestingQuestions.MaxNumberList[3] = Random.Range(1, 3);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 5 && TestingQuestions.MultiplicationCount < 10)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 21); TestingQuestions.MaxNumberList[1] = Random.Range(10, 21);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 10 && TestingQuestions.MultiplicationCount < 20)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 31); TestingQuestions.MaxNumberList[1] = Random.Range(10, 31);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 20 && TestingQuestions.MultiplicationCount < 30)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 41); TestingQuestions.MaxNumberList[1] = Random.Range(10, 41);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 30 && TestingQuestions.MultiplicationCount < 40)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 51); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 40 && TestingQuestions.MultiplicationCount < 42)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 31); TestingQuestions.MaxNumberList[1] = Random.Range(10, 31); TestingQuestions.MaxNumberList[2] = Random.Range(1, 3);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 42 && TestingQuestions.MultiplicationCount < 44)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 31); TestingQuestions.MaxNumberList[1] = Random.Range(10, 31); TestingQuestions.MaxNumberList[2] = Random.Range(1, 3); TestingQuestions.MaxNumberList[3] = Random.Range(1, 2);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 44 && TestingQuestions.MultiplicationCount < 54)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 71); TestingQuestions.MaxNumberList[1] = Random.Range(10, 31);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 54 && TestingQuestions.MultiplicationCount < 64)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 71); TestingQuestions.MaxNumberList[1] = Random.Range(10, 41);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 64 && TestingQuestions.MultiplicationCount < 74)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 101); TestingQuestions.MaxNumberList[1] = Random.Range(10, 101);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount == 74 )
        {
            TestingQuestions.MultiplicationCount = 39;
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 101); TestingQuestions.MaxNumberList[1] = Random.Range(10, 101);
            GenerateDigits.generateDigits();
        }

        // Don't use this part for now. Maybe future it will be available. This part is very hard for people...

        /*else if (TestingQuestions.MultiplicationCount >= 11 && TestingQuestions.MultiplicationCount < 13)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 13 && TestingQuestions.MultiplicationCount < 15)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(0, 2);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 15 && TestingQuestions.MultiplicationCount < 17)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(0, 6);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 17 && TestingQuestions.MultiplicationCount < 19)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 19)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }*/
    }
}