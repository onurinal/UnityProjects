using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.LevelSystem;
using BlockBreaker.Ball;

namespace BlockBreaker.Paddle
{
    public class PaddleController : MonoBehaviour
    {
        [Header("Paddle Properties")]
        [SerializeField] private PaddleProperties _playerProperties = null;

        private SpriteRenderer _paddle;
        private float _minXAndroid = 0f, _maxXAndroid = 0f;
        private float _paddleX = 0f;  // paddle x size to fix screen boundaries
        private void Start()
        {
            SetUpMovementBoundaries();
        }
        private void Update()
        {
            TouchMovement();
        }

        private void TouchMovement()
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.y = transform.position.y;
            touchPos.x = Mathf.Clamp(touchPos.x, _minXAndroid, _maxXAndroid);  // paddle can not go out of screen
            transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * _playerProperties.MovementSpeed);
        }
        private void SetUpMovementBoundaries()
        {
            // getting only x size because we don't need y size. Paddle can not move horizontally.
            _paddle = GetComponent<SpriteRenderer>(); 
            _paddleX = _paddle.bounds.size.x / 2;  // Because paddle sprite pivot is bottom center

            Camera gameCamera = Camera.main;
            _minXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _paddleX;  
            _maxXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _paddleX;
        }
    }
}
