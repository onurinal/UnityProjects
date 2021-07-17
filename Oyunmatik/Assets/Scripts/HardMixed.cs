using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMixed : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    HardAddition HardAddition;
    HardSubtraction HardSubtraction;
    HardMultiplication HardMultiplication;
    HardDivision HardDivision;

    public void hardMixed()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        HardAddition = gameObject.GetComponent<HardAddition>();
        HardSubtraction = gameObject.GetComponent<HardSubtraction>();
        HardMultiplication = gameObject.GetComponent<HardMultiplication>();
        HardDivision = gameObject.GetComponent<HardDivision>();

        TestingQuestions.CheckFunctionNumber = TestingQuestions.FunctionNumber[Random.Range(1, 5)];

        /* i need to mix four operations (Addition, Subtraction, Multiplication and Division).
         * that's why i created CheckFunctionNumber and FunctionNumber ( this is 5 size list) variable.
         * And then i am generating random numbers in 0,1,2,3 and then checking the random number.
         * If the number is 2 i am calling hardAddition() function. You can see the below.
         */

        if (TestingQuestions.CheckFunctionNumber == 2)
        {
            HardAddition.hardAddition();
        }
        else if (TestingQuestions.CheckFunctionNumber == 3)
        {
            HardSubtraction.hardSubtraction();
        }
        else if (TestingQuestions.CheckFunctionNumber == 4)
        {
            HardMultiplication.hardMultiplication();
        }
        else if (TestingQuestions.CheckFunctionNumber == 5)
        {
            HardDivision.hardDivision();
        }
    }
}
