using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckingScenes : MonoBehaviour
{
    EasyAddition EasyAddition;
    MediumAddition MediumAddition;
    HardAddition HardAddition;
    EasySubtraction EasySubtraction;
    MediumSubtraction MediumSubtraction;
    HardSubtraction HardSubtraction;
    EasyMultiplication EasyMultiplication;
    MediumMultiplication MediumMultiplication; // THIS SCRIPT CHECKING SCENES WHICH ARE EASY, MEDIUM OR HARD ...
    HardMultiplication HardMultiplication;
    EasyDivision EasyDivision;
    MediumDivision MediumDivision;
    HardDivision HardDivision;
    EasyMixed EasyMixed;
    MediumMixed MediumMixed;
    HardMixed HardMixed;
    Easy10Seconds Easy10Seconds;
    Medium10Seconds Medium10Seconds;
    Hard10Seconds Hard10Seconds;
    EasyMathDuel easyMathDuel;
    MediumMathDuel mediumMathDuel;
    HardMathDuel hardMathDuel;


    public void checkingScenes()
    {
        EasyAddition = gameObject.GetComponent<EasyAddition>();
        MediumAddition = gameObject.GetComponent<MediumAddition>();
        HardAddition = gameObject.GetComponent<HardAddition>();
        EasySubtraction = gameObject.GetComponent<EasySubtraction>();
        MediumSubtraction = gameObject.GetComponent<MediumSubtraction>();
        HardSubtraction = gameObject.GetComponent<HardSubtraction>();
        EasyMultiplication = gameObject.GetComponent<EasyMultiplication>();
        MediumMultiplication = gameObject.GetComponent<MediumMultiplication>();
        HardMultiplication = gameObject.GetComponent<HardMultiplication>();
        EasyDivision = gameObject.GetComponent<EasyDivision>();
        MediumDivision = gameObject.GetComponent<MediumDivision>();
        HardDivision = gameObject.GetComponent<HardDivision>();
        EasyMixed = gameObject.GetComponent<EasyMixed>();
        MediumMixed = gameObject.GetComponent<MediumMixed>();
        HardMixed = gameObject.GetComponent<HardMixed>();
        Easy10Seconds = gameObject.GetComponent<Easy10Seconds>();
        Medium10Seconds = gameObject.GetComponent<Medium10Seconds>();
        Hard10Seconds = gameObject.GetComponent<Hard10Seconds>();
        easyMathDuel = gameObject.GetComponent<EasyMathDuel>();
        mediumMathDuel = gameObject.GetComponent<MediumMathDuel>();
        hardMathDuel = gameObject.GetComponent<HardMathDuel>();

        string CheckingScenes = SceneManager.GetActiveScene().name;

        if (CheckingScenes.Equals("EasyAddition"))
        {
            EasyAddition.easyAddition();
        }
        else if (CheckingScenes.Equals("MediumAddition"))
        {
            MediumAddition.mediumAddition();
        }
        else if (CheckingScenes.Equals("HardAddition"))
        {
            HardAddition.hardAddition();
        }
        else if (CheckingScenes.Equals("EasySubtraction"))
        {
            EasySubtraction.easySubtraction();
        }
        else if (CheckingScenes.Equals("MediumSubtraction"))
        {
            MediumSubtraction.mediumSubtraction();
        }
        else if (CheckingScenes.Equals("HardSubtraction"))
        {
            HardSubtraction.hardSubtraction();
        }
        else if (CheckingScenes.Equals("EasyMultiplication"))
        {
            EasyMultiplication.easyMultiplication();
        }
        else if (CheckingScenes.Equals("MediumMultiplication"))
        {
            MediumMultiplication.mediumMultiplication();
        }
        else if (CheckingScenes.Equals("HardMultiplication"))
        {
            HardMultiplication.hardMultiplication();
        }
        else if (CheckingScenes.Equals("EasyDivision"))
        {
            EasyDivision.easyDivision();
        }
        else if (CheckingScenes.Equals("MediumDivision"))
        {
            MediumDivision.mediumDivision();
        }
        else if (CheckingScenes.Equals("HardDivision"))
        {
            HardDivision.hardDivision();
        }
        else if (CheckingScenes.Equals("EasyMixed"))
        {
            EasyMixed.easyMixed();
        }
        else if (CheckingScenes.Equals("MediumMixed"))
        {
            MediumMixed.mediumMixed();
        }
        else if (CheckingScenes.Equals("HardMixed"))
        {
            HardMixed.hardMixed();
        }
        else if (CheckingScenes.Equals("Easy10Seconds"))
        {
            Easy10Seconds.easy10Seconds();
        }
        else if (CheckingScenes.Equals("Medium10Seconds"))
        {
            Medium10Seconds.medium10Seconds();
        }
        else if (CheckingScenes.Equals("Hard10Seconds"))
        {
            Hard10Seconds.hard10Seconds();
        }
        else if (CheckingScenes.Equals("EasyMathDuel"))
        {
            easyMathDuel.EasyDuel();
        }
        else if (CheckingScenes.Equals("MediumMathDuel"))
        {
            mediumMathDuel.MediumDuel();
        }
        else if (CheckingScenes.Equals("HardMathDuel"))
        {
            hardMathDuel.HardDeul();
        }
    }
}