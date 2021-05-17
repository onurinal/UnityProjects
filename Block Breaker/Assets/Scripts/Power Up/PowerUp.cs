using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;

namespace BlockBreaker.ManagerSystem
{
    public class PowerUp : MonoBehaviour
    {
        private enum Effects
        {
            _multiBall,
            _extendPaddle,
            _shrinkPaddle,
            _laser
        }
        [SerializeField] private Effects _effects;

        [SerializeField] private PowerUpProperties _powerUpProperties = null; // access scriptableobject

        private GameManager _gameManager;
        private PowerUpManager _powerUpManager;
        private PaddleController _paddleController;
        private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            AccessObjects();
            SetUpDropSpeed();
        }
        private void AccessObjects()
        {
            _gameManager = GameManager.Instance;
            _powerUpManager = PowerUpManager.Instance;
            _paddleController = PaddleController.Instance;
        }
        // ----------------------- MANAGE POWER UPS DROP SPEED ---------------
        private void SetUpDropSpeed()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(_powerUpProperties.DropXSpeed, -(_powerUpProperties.DropYSpeed));
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ApplyPowerUpEffects();
                Destroy(gameObject);
            }
        }
        // ----------------------- APPLYING POWER UP EFFECTS --------------
        private void ApplyPowerUpEffects()
        {
            switch (_effects)
            {
                case Effects._multiBall: _gameManager.MultiBall();
                    break;

                case Effects._extendPaddle: _powerUpManager.StartExtendPaddle();
                    break;

                case Effects._shrinkPaddle: _powerUpManager.StartShrinkPaddle();
                    break;

                case Effects._laser:
                    // CHECKING ACTIVE LASER POWER UP. IF PLAYER GOT IT BEFORE THEN STOP SHOOTING AND START TIMING AGAIN
                    if(_paddleController._laserEndTime > 0)
                    {
                        _paddleController.StopAllCoroutines();
                    }
                    _paddleController.StartLaserShot();
                    break;
            }
        }
    }
}