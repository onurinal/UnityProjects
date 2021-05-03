using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BlockBreaker.ManagerSystem
{
    public class ScoreManager : MonoBehaviour
    {
       [SerializeField] private TextMeshProUGUI _scoreText;
       [SerializeField] private int _currentScore;

        public static ScoreManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        // ----------------------- ADDING SCORE ---------------
        public void AddToScore(int perPointBlockDestroyed)
        {
            _currentScore = _currentScore + perPointBlockDestroyed;
            _scoreText.text = _currentScore.ToString();
        }
    }
}
