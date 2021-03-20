using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard10Seconds : MonoBehaviour
{
    HardMixed HardMixed;

    public void hard10Seconds()
    {
        HardMixed = gameObject.GetComponent<HardMixed>();
        HardMixed.hardMixed();

        /* I'm calling hardMixed() function because there are 4 function in there.
         * They are addition(), subtraction(), multiplication() and division().
         * These functions generating randomly numbers for four operations in mathematic
         */
    }
}
