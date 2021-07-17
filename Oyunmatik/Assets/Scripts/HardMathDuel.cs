using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMathDuel : MonoBehaviour
{
    HardMixed HardMixed;

    public void HardDeul()
    {
        HardMixed = gameObject.GetComponent<HardMixed>();
        HardMixed.hardMixed();
    }
}
