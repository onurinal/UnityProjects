using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.ManagerSystem;

namespace BlockBreaker.ManagerSystem
{
    public class PowerUp : MonoBehaviour
    {
        private enum Effects
        {
            _multiBall,
            _increasingPaddleSize,
            _decreasingPaddleSize,
            _laser
        }
        [SerializeField] private Effects _effects;

        [SerializeField] private PowerUpProperties _powerUpProperties = null; // access scriptableobject

        private GameManager _gameManager;
        private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            DropSpeed();
        }
        // ----------------------- MANAGE POWER UPS DROP SPEED ---------------
        private void DropSpeed()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(_powerUpProperties.DropXSpeed, -_powerUpProperties.DropYSpeed);
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
                case Effects._multiBall:
                    _gameManager.MultiBall();
                    break;

                case Effects._increasingPaddleSize:
                    break;

                case Effects._decreasingPaddleSize:
                    break;

                case Effects._laser:
                    break;
            }
        }
    }
}