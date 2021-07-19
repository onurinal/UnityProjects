using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker.ManagerSystem;
using UnityEngine;

namespace BlockBreaker.Block
{
    public class DeathBlock : BaseBlock
    {
        [SerializeField] private BlockProperties _blockProperties;
        
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;

        private GameManager _gameManager;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }
        public override void TakeDamage(int damage)
        {
            blockLife = blockLife - damage;
            if (blockLife <= 0)
            {
                _boxCollider2D.isTrigger = true;
                _rigidbody2D.velocity = new Vector2(_blockProperties.DeathBlockXSpeed, _blockProperties.DeathBlockYSpeed);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _gameManager.DestroyAllBall();
                _gameManager.RemoveLife();
                Destroy(gameObject);
            }
        }
    }
}