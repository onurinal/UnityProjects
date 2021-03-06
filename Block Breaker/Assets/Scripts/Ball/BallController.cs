using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Block;

namespace BlockBreaker.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallProperties _ballProperties;  // for ball properties

        private Rigidbody2D _rigidbody2D;
        private float _magnitudeSpeed;  // to make the ball constant speed

        public bool BallLaunched; // to check ball is launched or not
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        // ----------------------- LAUNCH THE BALL ---------------
        public void LaunchBall()
        {
            if (BallLaunched) return;
            _rigidbody2D.velocity = new Vector2(_ballProperties.BallXSpeed, _ballProperties.BallYSpeed);
            BallLaunched = true;

            transform.SetParent(null); // Parent back to the world.
        }
        // ----------------------- DAMAGE TO BLOCKS BY BALL ---------------
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<BaseBlock>()?.TakeDamage(_ballProperties.BallDamage); // Short version of the code below
            //BlockController _blockController = collision.gameObject.GetComponent<BlockController>();
            //if (_blockController != null)
            //{
            //    _blockController.TakeDamage();
            //}
        }
        // ----------------------- MAKING BALL CONSTANT SPEED ---------------
        private void OnCollisionExit2D()
        {
            _magnitudeSpeed = _rigidbody2D.velocity.magnitude;
            if (_magnitudeSpeed > _ballProperties.BallBaseSpeed || _magnitudeSpeed < _ballProperties.BallBaseSpeed)
            {
                _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _ballProperties.BallBaseSpeed;
            }
        }
    }

}