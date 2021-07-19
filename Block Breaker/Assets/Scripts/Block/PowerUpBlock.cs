using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker.DestroySystem;
using BlockBreaker.ManagerSystem;
using UnityEngine;

namespace BlockBreaker.Block
{
    public class PowerUpBlock : BaseBlock, Destructible
    {
        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private PowerUpManager _powerUpManager;
        
        private void Start()
        {
            AccessObjects();
            _gameManager.CountBreakableBlock(gameObject);
        }
        private void AccessObjects()
        {
            _gameManager = GameManager.Instance;
            _scoreManager = ScoreManager.Instance;
            _powerUpManager = PowerUpManager.Instance;
        }
        public override void TakeDamage(int damage)
        {
            blockLife = blockLife - damage;
            if (blockLife <= 0)
            {
                DestroyBlock();
            }
        }
        public void DestroyBlock()
        {
            // Sometimes balls hit same block at the same time. That is why we need to use bool variable for fix
            if (isBlockAlive)
            {
                _scoreManager.AddToScore(pointPerBlockDestroyed); // add points each block
                isBlockAlive = false;
                GetComponent<Collider2D>().enabled = false; // no collider when it needs to be destroyed
                GetComponent<SpriteRenderer>().enabled = false; // no sprite when it needs to be destroyed
                Instantiate(breakParticlePrefab, transform.position, Quaternion.identity); // create particle when block has no life
                _powerUpManager.DropPowerUp(transform.position); // drop power up
            }
            _gameManager.RemoveBreakableBlock(gameObject); // remove block in list
            Destroy(gameObject);  // destroy the block
        }
    }
}
