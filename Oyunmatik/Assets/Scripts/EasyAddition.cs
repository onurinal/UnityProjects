using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAddition : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    GenerateDigits GenerateDigits;

    public void easyAddition()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        GenerateDigits = gameObject.GetComponent<GenerateDigits>();
        TestingQuestions.AdditionCount++;

        if (TestingQuestions.AdditionCount < 11)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(0, 10); TestingQuestions.MaxNumberList[1] = Random.Range(0, 10);
            GenerateDigits.generateDigits();
        }
        if (TestingQuestions.AdditionCount >= 11 && TestingQuestions.AdditionCount < 16)
        {
            TestingQuestions.DigitChoices = 1;
            TestingQuestions.MaxNumberList[0] = Random.Range(1, 10); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 16 && TestingQuestions.AdditionCount < 26)
        {
            TestingQuestions.DigitChoices = 2;
            TestingQuestions.MaxNumberList[0] = Random.Range(0, 10); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 26 && TestingQuestions.AdditionCount < 36)
        {
            TestingQuestions.DigitChoices = 3;
            TestingQuestions.MaxNumberList[0] = Random.Range(0, 10); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 36 && TestingQuestions.AdditionCount < 46)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 51); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 46 && TestingQuestions.AdditionCount < 56)
        {
            TestingQuestions.DigitChoices = 4;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount >= 56 && TestingQuestions.AdditionCount < 66)
        {
            TestingQuestions.DigitChoices = 5;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if(TestingQuestions.AdditionCount >= 66 && TestingQuestions.AdditionCount < 76)
        {
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
        else if (TestingQuestions.AdditionCount == 76)
        {
            TestingQuestions.AdditionCount = 36; // Reset level in the middle.
            TestingQuestions.DigitChoices = 6;
            TestingQuestions.MaxNumberList[0] = Random.Range(10, 100); TestingQuestions.MaxNumberList[1] = Random.Range(1, 10); TestingQuestions.MaxNumberList[2] = Random.Range(1, 10); TestingQuestions.MaxNumberList[3] = Random.Range(1, 10);
            GenerateDigits.generateDigits();
        }
    }
}
