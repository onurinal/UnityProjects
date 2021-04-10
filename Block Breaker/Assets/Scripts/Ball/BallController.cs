using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Block;

namespace BlockBreaker.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallProperties _ballProperties = null;  // for ball properties

        private Rigidbody2D _rigidBody2D;
        private float _magnitudeSpeed;  // to make the ball constant speed

        public bool BallLaunched;
        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }
        // ----------------------- LAUNCH THE BALL ---------------
        public void LaunchBall()
        {
            if (!BallLaunched)
            {
                _rigidBody2D.velocity = new Vector2(_ballProperties.BallXSpeed, _ballProperties.BallYSpeed);
                BallLaunched = true;

                transform.SetParent(transform.parent.parent); // Parent back to the world.
            }
        }
        // ----------------------- DAMAGE TO BLOCKS BY BALL ---------------
        private void OnCollisionEnter2D(Collision2D collision)
        {
            BlockController _blockController = collision.gameObject.GetComponent<BlockController>();
            if (_blockController != null)
            {
                _blockController.TakeDamage();
            }
        }
        // ----------------------- MAKING BALL CONSTANT SPEED ---------------
        private void OnCollisionExit2D(Collision2D collision)
        {
            _magnitudeSpeed = _rigidBody2D.velocity.magnitude;
            if (_magnitudeSpeed > _ballProperties.BallBaseSpeed || _magnitudeSpeed < _ballProperties.BallBaseSpeed)
            {
                _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * _ballProperties.BallBaseSpeed;
            }
        }
    }

}