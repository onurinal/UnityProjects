using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Block;
using BlockBreaker.Paddle;

namespace BlockBreaker.ManagerSystem
{
    public class LaserShot : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties;

        private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            AccessObjects();
            SetUpLaserMovement();
            Destroy(gameObject, 2f); // Destroy laser after 2 second
        }
        private void AccessObjects()
        {
        }
        private void SetUpLaserMovement()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(0f, _powerUpProperties.LaserSpeedY);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // If block is unbreakable then do not anything just destroy the laser object
            BlockController blockController = collision.GetComponent<BlockController>();
            if (blockController != null)
            {
                blockController.TakeDamage(_powerUpProperties.LaserDamage);
            }
            Destroy(gameObject);
        }
    }
}
