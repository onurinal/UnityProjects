using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium10Seconds : MonoBehaviour
{
    MediumMixed MediumMixed;

    public void medium10Seconds()
    {
        MediumMixed = gameObject.GetComponent<MediumMixed>();
        MediumMixed.mediumMixed();

        /* I'm calling mediumMixed() function because there are 4 function in there.
         * They are addition(), subtraction(), multiplication() and division().
         * These functions generating randomly numbers for four operations in mathematic
         */
    }
}
