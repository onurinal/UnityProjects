using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BlockBreaker.Ball;

namespace BlockBreaker.LevelSystem{
    public class GameOverCollider : MonoBehaviour
    {
        private BallController _ballController;
        
        private void Start()
        {
            _ballController = FindObjectOfType<BallController>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //SceneManager.LoadScene("Game Over"); // Do it when you don't have life
            _ballController.GameStarted = false;  // testing ... Reset the game and play again. Add 3 life after testing.
        }
    }

}
