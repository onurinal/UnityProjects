using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BlockBreaker.Block;

namespace BlockBreaker.LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int _breakableBlocks;

        // for updating score
        [SerializeField] private int _currentScore = 0;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private SceneLoader _sceneLoader;
        void Start()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>(); // to access SceneLoader component
            _scoreText.text = _currentScore.ToString();    // updating score for each level. It becomes 0.
        }

        void Update()
        {

        }
        public void CountBreakableBlocks()
        {
            _breakableBlocks++;
        }
        public void BlockDestroyed()
        {
            _breakableBlocks--; // While the ball destroys blocks, this line reduces the number of breakable blocks
            if(_breakableBlocks <= 0)
            {
                _sceneLoader.LoadNextScene();  // load next level when no blocks around space
            }
        }
        public void AddToScore(int perPointBlockDestroyed)
        {
            _currentScore = _currentScore + perPointBlockDestroyed;
            _scoreText.text = _currentScore.ToString();
        }
    }
}
