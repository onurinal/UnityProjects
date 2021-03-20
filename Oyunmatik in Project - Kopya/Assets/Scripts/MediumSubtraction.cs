using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSubtraction : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void mediumSubtraction()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.SubtractionCount++;

        if (TestingQuestions.SubtractionCount < 11)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(30, 51); TestingQuestions.MaxNumberList[1] = Random.Range(10, 31);
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.SubtractionCount >= 11 && TestingQuestions.SubtractionCount < 21)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(50, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 21 && TestingQuestions.SubtractionCount < 23)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(60, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 23 && TestingQuestions.SubtractionCount < 25)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(70, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 25 && TestingQuestions.SubtractionCount < 27)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(80, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51); TestingQuestions.MaxNumberList[2] = Random.Range(10, 31);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 27 && TestingQuestions.SubtractionCount < 29)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(90, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 51); TestingQuestions.MaxNumberList[2] = Random.Range(10, 31); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 29 && TestingQuestions.SubtractionCount < 31)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(90, 100); TestingQuestions.MaxNumberList[1] = Random.Range(10, 41); TestingQuestions.MaxNumberList[2] = Random.Range(10, 31); TestingQuestions.MaxNumberList[3] = Random.Range(10, 21);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 31 && TestingQuestions.SubtractionCount < 41)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 200); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 41 && TestingQuestions.SubtractionCount < 44)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 250); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 44 && TestingQuestions.SubtractionCount < 46)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 350); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 46 && TestingQuestions.SubtractionCount < 56)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(100, 400); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 56 && TestingQuestions.SubtractionCount < 58)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(200, 450); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 58 && TestingQuestions.SubtractionCount < 60)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(200, 500); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 60 && TestingQuestions.SubtractionCount < 63)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(250, 600); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 63 && TestingQuestions.SubtractionCount < 73)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 600); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 73 && TestingQuestions.SubtractionCount < 75)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 600); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 75 && TestingQuestions.SubtractionCount < 77)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(400, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100); TestingQuestions.MaxNumberList[2] = Random.Range(10, 100); TestingQuestions.MaxNumberList[3] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
        else if(TestingQuestions.SubtractionCount == 77)
        {
            TestingQuestions.SubtractionCount = 46;
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 600); TestingQuestions.MaxNumberList[1] = Random.Range(10, 100);
            GenerateDigits.generateDigits();
        }
    }
}