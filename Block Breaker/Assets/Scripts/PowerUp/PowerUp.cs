using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.ManagerSystem;
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
        private PaddleController _paddleController;
        private PowerUpManager _powerUpManager;
        private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            AccessObjects();
            SetupDropSpeed();
        }

        private void AccessObjects()
        {
            _gameManager = GameManager.Instance;
            _paddleController = PaddleController.Instance;
            _powerUpManager = PowerUpManager.Instance;
        }

        // ----------------------- MANAGE POWER UPS DROP SPEED ---------------
        private void SetupDropSpeed()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(_powerUpProperties.DropXSpeed, -(_powerUpProperties.DropYSpeed));
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ApplyEffects();
                Destroy(gameObject);
            }
        }
        // ----------------------- APPLYING POWER UP EFFECTS --------------
        private void ApplyEffects()
        {
            switch (_effects)
            {
                case Effects._multiBall: _gameManager.MultiBall();
                    break;

                case Effects._extendPaddle: _powerUpManager.ExtendPaddleCoroutine();
                    break;

                case Effects._shrinkPaddle: _powerUpManager.ShrinkPaddleCoroutine();
                    break;

                case Effects._laser:
                    break;
            }
        }
    }
}