using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSubtraction : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void hardSubtraction()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.SubtractionCount++;

        if (TestingQuestions.SubtractionCount < 11)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(200, 401); TestingQuestions.MaxNumberList[1] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.SubtractionCount >= 11 && TestingQuestions.SubtractionCount < 21)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501); TestingQuestions.MaxNumberList[1] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.SubtractionCount >= 21 && TestingQuestions.SubtractionCount < 26)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(300, 501); TestingQuestions.MaxNumberList[1] = Random.Range(100, 301);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 26 && TestingQuestions.SubtractionCount < 31)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(400, 601); TestingQuestions.MaxNumberList[1] = Random.Range(100, 391); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 31 && TestingQuestions.SubtractionCount < 36)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(500, 601); TestingQuestions.MaxNumberList[1] = Random.Range(100, 401); TestingQuestions.MaxNumberList[2] = Random.Range(1, 11); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 36 && TestingQuestions.SubtractionCount < 46)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(600, 801); TestingQuestions.MaxNumberList[1] = Random.Range(100, 501); TestingQuestions.MaxNumberList[2] = Random.Range(10, 101);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 46 && TestingQuestions.SubtractionCount < 49)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(900, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 701); TestingQuestions.MaxNumberList[2] = Random.Range(10, 101); TestingQuestions.MaxNumberList[3] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 49 && TestingQuestions.SubtractionCount < 52)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(900, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 701); TestingQuestions.MaxNumberList[2] = Random.Range(10, 101); TestingQuestions.MaxNumberList[3] = Random.Range(10, 101);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 52 && TestingQuestions.SubtractionCount < 62)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(500, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 301); TestingQuestions.MaxNumberList[2] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 62 && TestingQuestions.SubtractionCount < 65)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(700, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 501); TestingQuestions.MaxNumberList[2] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 65 && TestingQuestions.SubtractionCount < 68)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(500, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 201); TestingQuestions.MaxNumberList[2] = Random.Range(100, 201); TestingQuestions.MaxNumberList[3] = Random.Range(10, 101);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 68 && TestingQuestions.SubtractionCount < 73)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(700, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 301); TestingQuestions.MaxNumberList[2] = Random.Range(100, 201); TestingQuestions.MaxNumberList[3] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 73 && TestingQuestions.SubtractionCount < 78)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(900, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 401); TestingQuestions.MaxNumberList[2] = Random.Range(100, 301); TestingQuestions.MaxNumberList[3] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount == 78)
        {
            TestingQuestions.SubtractionCount = 52;
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(900, 1000); TestingQuestions.MaxNumberList[1] = Random.Range(100, 401); TestingQuestions.MaxNumberList[2] = Random.Range(100, 301); TestingQuestions.MaxNumberList[3] = Random.Range(100, 201);
            GenerateDigits.generateDigits();
        }
    }
}