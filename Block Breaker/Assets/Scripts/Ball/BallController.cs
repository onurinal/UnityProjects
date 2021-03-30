using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallProperties _ballProperties = null;
    [SerializeField] private GameObject _paddle;
    Vector2 ballToPaddleVector;
    private bool gameStarted = false;
    void Start()
    {
        BallToPaddleVector();
    }
    void Update()
    {
        if (!gameStarted)
        {
            StickBallToPaddle();
            LaunchOnBall();
        }
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
            gameStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(_ballProperties.BallXSpeed, _ballProperties.BallYSpeed);
        }
    }
    private void BallToPaddleVector() // to find the distance of the ball to paddle
    {
        ballToPaddleVector = transform.position - _paddle.transform.position;
    }
}
