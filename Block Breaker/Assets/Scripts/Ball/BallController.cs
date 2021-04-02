using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallProperties _ballProperties = null;  // for ball properties
        [SerializeField] private GameObject _paddle; // to find paddle position and stick to the ball
        Vector2 ballToPaddleVector; // to find the distance of the ball to paddle

        private bool _gameStarted = false;

        private Rigidbody2D _rigidBody2D;
        void Start()
        {
            BallToPaddleVector();
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            if (!_gameStarted)
            {
                StickBallToPaddle();
                LaunchOnBall();
            }
        }
        private void BallToPaddleVector() // to find the distance of the ball to paddle
        {
            ballToPaddleVector = transform.position - _paddle.transform.position;
        }
        private void StickBallToPaddle()
        {
            Vector2 paddlePos = new Vector2(_paddle.transform.position.x, _paddle.transform.position.y);
            transform.position = paddlePos + ballToPaddleVector; // make it to move with the paddle
        }
        private void LaunchOnBall()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gameStarted = true;
                _rigidBody2D.velocity = new Vector2(_ballProperties.BallXSpeed, _ballProperties.BallYSpeed);
            }
        }


        public bool GameStarted // testing.. Reset the game. Look in LoseCollider.cs
        {
            set { _gameStarted = value; }
        }
    }

}