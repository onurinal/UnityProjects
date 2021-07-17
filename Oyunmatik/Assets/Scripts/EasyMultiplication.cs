using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EasyMultiplication : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void easyMultiplication()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.MultiplicationCount++;

        if (TestingQuestions.MultiplicationCount < 6)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(0, 11); TestingQuestions.MaxNumberList[1] = Random.Range(0, 11);
            TestingQuestions.DigitChoices = 1;
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.MultiplicationCount >= 6 && TestingQuestions.MultiplicationCount < 21)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(1, 11); TestingQuestions.MaxNumberList[1] = Random.Range(1, 11);
            TestingQuestions.DigitChoices = 1;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 21 && TestingQuestions.MultiplicationCount < 24)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(0, 4); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(2, 4);
            TestingQuestions.DigitChoices = 2;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 24 && TestingQuestions.MultiplicationCount < 29)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(1, 4); TestingQuestions.MaxNumberList[1] = Random.Range(2, 4); TestingQuestions.MaxNumberList[2] = Random.Range(2, 4); TestingQuestions.MaxNumberList[3] = Random.Range(1, 3);
            TestingQuestions.DigitChoices = 3;
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.MultiplicationCount >= 29 && TestingQuestions.MultiplicationCount < 39)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(5, 11); TestingQuestions.MaxNumberList[1] = Random.Range(3, 11);
            TestingQuestions.DigitChoices = 1;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 39 && TestingQuestions.MultiplicationCount < 42)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(2, 5); TestingQuestions.MaxNumberList[1] = Random.Range(2, 5); TestingQuestions.MaxNumberList[2] = Random.Range(2, 5);
            TestingQuestions.DigitChoices = 2;
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.MultiplicationCount >= 42 && TestingQuestions.MultiplicationCount < 45)
        {
            TestingQuestions.MaxNumberList[0] = Random.Range(1, 4); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(1, 4); TestingQuestions.MaxNumberList[3] = Random.Range(1, 3);
            TestingQuestions.DigitChoices = 3;
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.MultiplicationCount == 45)
        {
            TestingQuestions.MultiplicationCount = 29;
            TestingQuestions.MaxNumberList[0] = Random.Range(1, 4); TestingQuestions.MaxNumberList[1] = Random.Range(1, 4); TestingQuestions.MaxNumberList[2] = Random.Range(1, 4); TestingQuestions.MaxNumberList[3] = Random.Range(1, 3);
            TestingQuestions.DigitChoices = 3;
            GenerateDigits.generateDigits();
        }
    }
}
