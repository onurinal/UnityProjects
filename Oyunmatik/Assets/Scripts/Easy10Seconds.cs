using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Easy10Seconds : MonoBehaviour
{
    EasyMixed EasyMixed;

    public void easy10Seconds()
    {
        EasyMixed = gameObject.GetComponent<EasyMixed>();
        EasyMixed.easyMixed();

        /* I'm calling easyMixed() function because there are 4 function in there.
         * They are addition(), subtraction(), multiplication() and division().
         * These functions generating randomly numbers for four operations in mathematic
         */
    }
}