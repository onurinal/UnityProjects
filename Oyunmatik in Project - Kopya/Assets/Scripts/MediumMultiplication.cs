using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumMultiplication : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void mediumMultiplication()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.MultiplicationCount++;

        if (TestingQuestions.MultiplicationCount < 3)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 6); TestingQuestions.MaxNumberList[1] = Random.Range(2, 6); TestingQuestions.MaxNumberList[2] = Random.Range(2, 6);
            TestingQuestions.DigitChoices = 2;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 3 && TestingQuestions.MultiplicationCount < 5)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 6); TestingQuestions.MaxNumberList[1] = Random.Range(2, 6); TestingQuestions.MaxNumberList[2] = Random.Range(2, 4); TestingQuestions.MaxNumberList[3] = Random.Range(1, 4);
            TestingQuestions.DigitChoices = 3;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 5 && TestingQuestions.MultiplicationCount < 20)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 40); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 20 && TestingQuestions.MultiplicationCount < 35)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(20, 60); TestingQuestions.MaxNumberList[1] = Random.Range(3, 6);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 35 && TestingQuestions.MultiplicationCount < 50)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(20, 80); TestingQuestions.MaxNumberList[1] = Random.Range(5, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 50 && TestingQuestions.MultiplicationCount < 55)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount == 55)
        {
            TestingQuestions.MultiplicationCount = 20;
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11);
            GenerateDigits.generateDigits();
        }
    }
}