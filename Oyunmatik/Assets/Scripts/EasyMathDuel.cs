using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMathDuel : MonoBehaviour
{
    EasyMixed easyMixed;
    
    public void EasyDuel()
    {
        easyMixed = gameObject.GetComponent<EasyMixed>();
        easyMixed.easyMixed();
    }
}
