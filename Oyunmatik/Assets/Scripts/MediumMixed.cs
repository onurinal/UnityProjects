using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumMixed : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    MediumAddition MediumAddition;
    MediumSubtraction MediumSubtraction;
    MediumMultiplication MediumMultiplication;
    MediumDivision MediumDivision;

    public void mediumMixed()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        MediumAddition = gameObject.GetComponent<MediumAddition>();
        MediumSubtraction = gameObject.GetComponent<MediumSubtraction>();
        MediumMultiplication = gameObject.GetComponent<MediumMultiplication>();
        MediumDivision = gameObject.GetComponent<MediumDivision>();

        TestingQuestions.CheckFunctionNumber = TestingQuestions.FunctionNumber[Random.Range(1, 5)];

        /* i need to mix four operations (Addition, Subtraction, Multiplication and Division).
         * that's why i created CheckFunctionNumber and FunctionNumber ( this is 5 size list) variable.
         * And then i am generating random numbers in 0,1,2,3 and then checking the random number.
         * If the number is 2 i am calling mediumAddition() function. You can see the below.
         */

        if (TestingQuestions.CheckFunctionNumber == 2)
        {
            MediumAddition.mediumAddition();
        }
        else if (TestingQuestions.CheckFunctionNumber == 3)
        {
            MediumSubtraction.mediumSubtraction();
        }
        else if (TestingQuestions.CheckFunctionNumber == 4)
        {
            MediumMultiplication.mediumMultiplication();
        }
        else if (TestingQuestions.CheckFunctionNumber == 5)
        {
            MediumDivision.mediumDivision();
        }
    }
}
