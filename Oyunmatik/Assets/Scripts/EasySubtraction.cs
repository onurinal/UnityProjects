using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySubtraction : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void easySubtraction()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.SubtractionCount++;

        if (TestingQuestions.SubtractionCount < 6)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(5, 10); TestingQuestions.MaxNumberList[1] = Random.Range(0, 6);
            TestingQuestions.DigitChoices = 1;
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.SubtractionCount >= 6 && TestingQuestions.SubtractionCount < 11)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(8, 11); TestingQuestions.MaxNumberList[1] = Random.Range(1, 9);
            TestingQuestions.DigitChoices = 1;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 11 && TestingQuestions.SubtractionCount < 16)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(7, 11); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(0, 4);
            TestingQuestions.DigitChoices = 2;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 16 && TestingQuestions.SubtractionCount < 21)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 15); TestingQuestions.MaxNumberList[1] = Random.Range(1, 5); TestingQuestions.MaxNumberList[2] = Random.Range(1, 5); TestingQuestions.MaxNumberList[3] = Random.Range(1, 3);
            TestingQuestions.DigitChoices = 3;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 21 && TestingQuestions.SubtractionCount < 31)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 51); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 31 && TestingQuestions.SubtractionCount < 36)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(30, 71); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 36 && TestingQuestions.SubtractionCount < 41)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(50, 100); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.SubtractionCount >= 41 && TestingQuestions.SubtractionCount < 46)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(20, 100); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11); TestingQuestions.MaxNumberList[2] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
        else if(TestingQuestions.SubtractionCount == 46)
        {
            TestingQuestions.SubtractionCount = 21; // Reset Levels
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(30, 100); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11); TestingQuestions.MaxNumberList[2] = Random.Range(5, 11); TestingQuestions.MaxNumberList[3] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
    }
}