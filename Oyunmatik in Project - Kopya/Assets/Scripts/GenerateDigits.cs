using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateDigits : MonoBehaviour
{
    TestingQuestions TestingQuestions;

    public void generateDigits()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>(); // to access values from TestingQuestions class.

        string CheckingScenes = SceneManager.GetActiveScene().name;

        if (CheckingScenes.Equals("EasyAddition") || CheckingScenes.Equals("MediumAddition") || CheckingScenes.Equals("HardAddition") || TestingQuestions.CheckFunctionNumber == 2)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " + " + TestingQuestions.MaxNumberList[1] + " = " + " ?";
                if(CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1];
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " + " + TestingQuestions.MaxNumberList[1] + " + " + TestingQuestions.MaxNumberList[2] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1] + TestingQuestions.MaxNumberList[2];
            }
            else if (TestingQuestions.DigitChoices == 3)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " + " + TestingQuestions.MaxNumberList[1] + " + " + TestingQuestions.MaxNumberList[2] + " + " + TestingQuestions.MaxNumberList[3] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1] + TestingQuestions.MaxNumberList[2] + TestingQuestions.MaxNumberList[3];
            }
            else if (TestingQuestions.DigitChoices == 4)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1];
                Minimize();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
            else if (TestingQuestions.DigitChoices == 5)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1] + TestingQuestions.MaxNumberList[2];
                Minimize1();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
            else if (TestingQuestions.DigitChoices == 6)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] + TestingQuestions.MaxNumberList[1] + TestingQuestions.MaxNumberList[2] + TestingQuestions.MaxNumberList[3];
                Minimize2();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " + " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
        }
        else if (CheckingScenes.Equals("EasySubtraction") || CheckingScenes.Equals("MediumSubtraction") || CheckingScenes.Equals("HardSubtraction") || TestingQuestions.CheckFunctionNumber == 3)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " - " + TestingQuestions.MaxNumberList[1] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] - TestingQuestions.MaxNumberList[1];
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " - " + TestingQuestions.MaxNumberList[1] + " - " + TestingQuestions.MaxNumberList[2] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] - TestingQuestions.MaxNumberList[1] - TestingQuestions.MaxNumberList[2];
            }
            else if (TestingQuestions.DigitChoices == 3)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " - " + TestingQuestions.MaxNumberList[1] + " - " + TestingQuestions.MaxNumberList[2] + " - " + TestingQuestions.MaxNumberList[3] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] - TestingQuestions.MaxNumberList[1] - TestingQuestions.MaxNumberList[2] - TestingQuestions.MaxNumberList[3];
            }
        }
        else if (CheckingScenes.Equals("EasyMultiplication") || CheckingScenes.Equals("MediumMultiplication") || CheckingScenes.Equals("HardMultiplication") || TestingQuestions.CheckFunctionNumber == 4)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " x " + TestingQuestions.MaxNumberList[1] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1];
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " x " + TestingQuestions.MaxNumberList[1] + " x " + TestingQuestions.MaxNumberList[2] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1] * TestingQuestions.MaxNumberList[2];
            }
            else if (TestingQuestions.DigitChoices == 3)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " x " + TestingQuestions.MaxNumberList[1] + " x " + TestingQuestions.MaxNumberList[2] + " x " + TestingQuestions.MaxNumberList[3] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1] * TestingQuestions.MaxNumberList[2] * TestingQuestions.MaxNumberList[3];
            }
            else if (TestingQuestions.DigitChoices == 4)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1];
                Minimize();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
            else if (TestingQuestions.DigitChoices == 5)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1] * TestingQuestions.MaxNumberList[2];
                Minimize1();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
            else if (TestingQuestions.DigitChoices == 6)
            {
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] * TestingQuestions.MaxNumberList[1] * TestingQuestions.MaxNumberList[2] * TestingQuestions.MaxNumberList[3];
                Minimize2();
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " x " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
            }
        }
        else if (CheckingScenes.Equals("EasyDivision") || CheckingScenes.Equals("MediumDivision") || CheckingScenes.Equals("HardDivision") || TestingQuestions.CheckFunctionNumber == 1 || TestingQuestions.CheckFunctionNumber == 5)
        {
            if (TestingQuestions.DigitChoices == 1)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " / " + TestingQuestions.MaxNumberList[1] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] / TestingQuestions.MaxNumberList[1];
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " / " + TestingQuestions.MaxNumberList[1] + " / " + TestingQuestions.MaxNumberList[2] + " = " + " ?";
                if (CheckingScenes.Equals("EasyMathDuel") || CheckingScenes.Equals("MediumMathDuel") || CheckingScenes.Equals("HardMathDuel"))
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.RandomQuestion.text;
                }
                TestingQuestions.result = TestingQuestions.MaxNumberList[0] / TestingQuestions.MaxNumberList[1] / TestingQuestions.MaxNumberList[2];
            }
        }
    }
    void Minimize()
    {
        if (TestingQuestions.DigitChoices == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                TestingQuestions.temp = TestingQuestions.TwoNumInOneList[i];
                TestingQuestions.randomIndex = Random.Range(0, 2);
                TestingQuestions.TwoNumInOneList[i] = TestingQuestions.TwoNumInOneList[TestingQuestions.randomIndex];
                TestingQuestions.TwoNumInOneList[TestingQuestions.randomIndex] = TestingQuestions.temp;
            }
        }
    }
    void Minimize1()
    {
        if (TestingQuestions.DigitChoices == 5)
        {
            for (int i = 0; i < 3; i++)
            {
                TestingQuestions.temp = TestingQuestions.ThreeNumInOneList[i];
                TestingQuestions.randomIndex = Random.Range(0, 3);
                TestingQuestions.ThreeNumInOneList[i] = TestingQuestions.ThreeNumInOneList[TestingQuestions.randomIndex];
                TestingQuestions.ThreeNumInOneList[TestingQuestions.randomIndex] = TestingQuestions.temp;
            }
        }
    }
    void Minimize2()
    {
        if (TestingQuestions.DigitChoices == 6)
        {
            for (int i = 0; i < 4; i++)
            {
                TestingQuestions.temp = TestingQuestions.FourNumInOneList[i];
                TestingQuestions.randomIndex = Random.Range(0, 4);
                TestingQuestions.FourNumInOneList[i] = TestingQuestions.FourNumInOneList[TestingQuestions.randomIndex];
                TestingQuestions.FourNumInOneList[TestingQuestions.randomIndex] = TestingQuestions.temp;
            }
        }
    }

    /* This script is keeping the results and showing the questions in the screen. In the beginning i am checking the scenes
     * with this function : CheckingScenes = SceneManager.GetActiveScene().name; . Because i need to know which scene is Addition part
     * or which one is division part like that. And then i have a DigitChoices variable.
     * I dont want two-digit and three-digit numbers to come at the beginning of the text always. That is why i need to use like this variable.
     * 
     *DigitCohices == 1 -> nothing happens. It just write the questions directly in screen.
     *DigitCohices == 2 -> nothing happens. It just write the questions directly in screen.
     *DigitCohices == 3 -> nothing happens. It just write the questions directly in screen.
     *DigitCohices == 4 -> They have 2 numbers and i swap number's places
     *DigitCohices == 5 -> They have 3 numbers and i swap number's places
     *DigitCohices == 6 -> They have 4 numbers and i swap number's places
     *For example : first question can be 78 + 2  and the second question can be 2 + 78 . Only for this. I used it to arrange them
     */
}