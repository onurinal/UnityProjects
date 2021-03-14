using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessMyNumber : MonoBehaviour
{
    [SerializeField] private int _max;
    [SerializeField] private int _min;
    [SerializeField] TextMeshProUGUI guessText;
    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GuessNumber();
    }
    private void GuessNumber()
    {

        
        guess = Random.Range(_min, _max + 1);
        guessText.text = guess.ToString();
    }
    public void onPressHigher()
    {
        if (_max == _min)
        {
            GuessNumber();
        }
        else
        {
            _min = guess + 1;
            GuessNumber();
        }
    }
    public void onPressLower()
    {
        if(_max == _min)
        {
            GuessNumber();
        }
        else
        {
            _max = guess - 1;
            GuessNumber();
        }
    }
}
