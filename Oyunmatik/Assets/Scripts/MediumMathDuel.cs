using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumMathDuel : MonoBehaviour
{
    MediumMixed MediumMixed;

    public void MediumDuel()
    {
        MediumMixed = gameObject.GetComponent<MediumMixed>();
        MediumMixed.mediumMixed();
    }
}