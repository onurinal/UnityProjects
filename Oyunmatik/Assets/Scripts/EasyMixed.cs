using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMixed : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    EasyAddition EasyAddition;
    EasySubtraction EasySubtraction;
    EasyMultiplication EasyMultiplication;
    EasyDivision EasyDivision;


    public void easyMixed()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        EasyAddition = gameObject.GetComponent<EasyAddition>();
        EasySubtraction = gameObject.GetComponent<EasySubtraction>();
        EasyMultiplication = gameObject.GetComponent<EasyMultiplication>();
        EasyDivision = gameObject.GetComponent<EasyDivision>();
        
        TestingQuestions.CheckFunctionNumber = TestingQuestions.FunctionNumber[Random.Range(0, 4)];

        /* i need to mix four operations (Addition, Subtraction, Multiplication and Division).
         * that's why i created CheckFunctionNumber and FunctionNumber ( this is 5 size list) variable.
         * And then i am generating random numbers in 0,1,2,3 and then checking the random number.
         * If the number is 2 i am calling easyAddition() function. You can see the below.
         */

        if (TestingQuestions.CheckFunctionNumber == 2)
        {
            EasyAddition.easyAddition();
        }
        else if(TestingQuestions.CheckFunctionNumber == 3)
        {
            EasySubtraction.easySubtraction();
        }
        else if (TestingQuestions.CheckFunctionNumber == 4)
        {
            EasyMultiplication.easyMultiplication();
        }
        else if (TestingQuestions.CheckFunctionNumber == 1)
        {
            EasyDivision.easyDivision();
        }
    }
}
