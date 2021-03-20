using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAddition : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void hardAddition()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.AdditionCount++;

        if (TestingQuestions.AdditionCount < 10)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 10 && TestingQuestions.AdditionCount < 16)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 16 && TestingQuestions.AdditionCount < 21)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 21 && TestingQuestions.AdditionCount < 26)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 26 && TestingQuestions.AdditionCount < 31)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 31 && TestingQuestions.AdditionCount < 36)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 36 && TestingQuestions.AdditionCount < 41)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(100, 1000);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 41 && TestingQuestions.AdditionCount < 46)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 46 && TestingQuestions.AdditionCount < 51)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 51 && TestingQuestions.AdditionCount < 56)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[3] = Random.Range(100, 1000);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount == 56)
        {
            TestingQuestions.AdditionCount = 41; // Reset Level
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[2] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[3] = Random.Range(100, 1000);
            GenerateDigits.generateDigits();
        }
    }
}