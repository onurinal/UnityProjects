using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAddition : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;
    public void mediumAddition()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.AdditionCount++;

        if (TestingQuestions.AdditionCount < 16)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 51); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51);
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.AdditionCount >= 16 && TestingQuestions.AdditionCount < 31)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }   
        else if (TestingQuestions.AdditionCount >= 31 && TestingQuestions.AdditionCount < 34)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 34 && TestingQuestions.AdditionCount < 37)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 37 && TestingQuestions.AdditionCount < 47)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 47 && TestingQuestions.AdditionCount < 50)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 50 && TestingQuestions.AdditionCount < 60)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 60 && TestingQuestions.AdditionCount < 65)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 65 && TestingQuestions.AdditionCount < 70)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 70 && TestingQuestions.AdditionCount < 75)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 75 && TestingQuestions.AdditionCount < 80)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 80 && TestingQuestions.AdditionCount < 85)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 85 && TestingQuestions.AdditionCount < 90)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 90 && TestingQuestions.AdditionCount < 95)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 95 && TestingQuestions.AdditionCount < 100)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 100 && TestingQuestions.AdditionCount < 105)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if(TestingQuestions.AdditionCount == 105)
        {
            TestingQuestions.AdditionCount = 75; // Reset Level in middle
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
    }
}