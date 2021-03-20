using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RenderingQuestionAnswers : MonoBehaviour
{
    TestingQuestions TestingQuestions;

    string CheckingScenes;

    void Awake()
    {
        CheckingScenes = SceneManager.GetActiveScene().name;
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
    }

    public void renderingQuestionAnswers()
    {
        string CurrentOperator;

        if (CheckingScenes == ("EasyAddition") || CheckingScenes == ("MediumAddition") || CheckingScenes == ("HardAddition") || TestingQuestions.CheckFunctionNumber == 2)
        {
            CurrentOperator = " + ";
            Minimize();
        }
        else if (CheckingScenes == ("EasySubtraction") || CheckingScenes == ("MediumSubtraction") || CheckingScenes == ("HardSubtraction") || TestingQuestions.CheckFunctionNumber == 3)
        {
            CurrentOperator = "-";
            Minimize();
        }
        else if (CheckingScenes == ("EasyMultiplication") || CheckingScenes == ("MediumMultiplication") || CheckingScenes == ("HardMultiplication") || TestingQuestions.CheckFunctionNumber == 4)
        {
            CurrentOperator = "x";
            Minimize();
        }
        else if (CheckingScenes == ("EasyDivision") || CheckingScenes == ("MediumDivision") || CheckingScenes == ("HardDivision") || TestingQuestions.CheckFunctionNumber == 1 || TestingQuestions.CheckFunctionNumber == 5)
        {
            CurrentOperator = "/";
            Minimize();
        } 
        void Minimize()
        {

            if (TestingQuestions.DigitChoices == 1)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 3)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[3] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[3] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 4)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 5)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " ? " + "      <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 6)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.RandomQuestion.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " ? " + "      <sprite=0>";
                }
            }
        }
    }
    public void RenderingQuestionAnswers2()
    {
        string CurrentOperator;

        if (CheckingScenes == ("EasyAddition") || CheckingScenes == ("MediumAddition") || CheckingScenes == ("HardAddition") || TestingQuestions.CheckFunctionNumber == 2)
        {
            CurrentOperator = " + ";
            Minimize();
        }
        else if (CheckingScenes == ("EasySubtraction") || CheckingScenes == ("MediumSubtraction") || CheckingScenes == ("HardSubtraction") || TestingQuestions.CheckFunctionNumber == 3)
        {
            CurrentOperator = "-";
            Minimize();
        }
        else if (CheckingScenes == ("EasyMultiplication") || CheckingScenes == ("MediumMultiplication") || CheckingScenes == ("HardMultiplication") || TestingQuestions.CheckFunctionNumber == 4)
        {
            CurrentOperator = "x";
            Minimize();
        }
        else if (CheckingScenes == ("EasyDivision") || CheckingScenes == ("MediumDivision") || CheckingScenes == ("HardDivision") || TestingQuestions.CheckFunctionNumber == 1 || TestingQuestions.CheckFunctionNumber == 5)
        {
            CurrentOperator = "/";
            Minimize();
        }
        void Minimize()
        {

            if (TestingQuestions.DigitChoices == 1)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 2)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 3)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[3] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[0] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[1] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[2] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[3] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 4)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";

                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.TwoNumInOneList[1]] + " = " + " ? " + "     <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 5)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.ThreeNumInOneList[2]] + " = " + " ? " + "      <sprite=0>";
                }
            }
            else if (TestingQuestions.DigitChoices == 6)
            {
                if (TestingQuestions.TrueOrFalse == 1)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " " + TestingQuestions.result + "      <sprite=1>";
                }
                else if (TestingQuestions.TrueOrFalse == 0)
                {
                    TestingQuestions.randomQuestion2.text = TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[0]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[1]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[2]] + " " + CurrentOperator + " " + TestingQuestions.MaxNumberList[TestingQuestions.FourNumInOneList[3]] + " = " + " ? " + "      <sprite=0>";
                }
            }
        }
    }
    // THIS PART JUST SHOWING THE QUESTIONS WITH TEXT IN SCREEN.
}