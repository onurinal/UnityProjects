using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Properties")]
        [SerializeField] private PlayerProperties _playerProperties = null;

        private float _minXAndroid = 0f, _maxXAndroid = 0f;

        private SpriteRenderer _paddle;
        private float _paddleX = 0f;  // paddle x size to fix screen boundaries
        void Start()
        {
            _paddle = GetComponent<SpriteRenderer>();
            GetPaddleSizeX();
            SetUpMovementBoundaries();
        }


        void Update()
        {   
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.y = transform.position.y;
            touchPos.x = Mathf.Clamp(touchPos.x, _minXAndroid, _maxXAndroid);  // Player can not go out of screen
            transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * _playerProperties.MovementSpeed);

        }

        private void SetUpMovementBoundaries()
        {
            Camera gameCamera = Camera.main;

            _minXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _paddleX ;  
            _maxXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _paddleX;
        }
        private void GetPaddleSizeX()  // getting only x size because we don't need y axis. Paddle can not move horizontally.
        {
            _paddleX = _paddle.bounds.size.x / 2;  // Because Player sprite pivot is bottom center
        }
    }
}
