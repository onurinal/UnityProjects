using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.ManagerSystem;

namespace BlockBreaker.Block
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private int _blockLife;
        [SerializeField] private Sprite[] _blockSpriteList;
        [SerializeField] private int _pointPerBlockDestroyed;

        private SpriteRenderer _blockSprite;
        private bool _isBlockAlive = true;

        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private PowerUpManager _powerUpManager;
        private void Start()
        {
            AccesingObjects();
            CountBreakableBlocks();
        }
        private void AccesingObjects()
        {
            _gameManager = GameManager.Instance;
            _scoreManager = ScoreManager.Instance;
            _powerUpManager = PowerUpManager.Instance;
            _blockSprite = GetComponent<SpriteRenderer>();
        }
        private void CountBreakableBlocks()
        {
            _gameManager.CountBreakableBlock(gameObject);
        }
        public void TakeDamage(int damage)
        {
            _blockLife = _blockLife - damage;
            if (_blockLife <= 0)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextBlockSprite();
            }
        }
        public void ShowNextBlockSprite()
        {
            int _spriteIndex = _blockLife - 1;  // _blockSprite size is 2 so when red block got hit, _spriteIndex must be "1".
            _blockSprite.sprite = _blockSpriteList[_spriteIndex];
        }
        private void DestroyBlock()
        {
            _gameManager.RemoveBreakableBlock(gameObject); // remove block in list
            // Sometimes balls hit same block at the same time. Thats why we need to use bool variable for fix
            if (_isBlockAlive)
            {
                _scoreManager.AddToScore(_pointPerBlockDestroyed); // add points each block
                _isBlockAlive = false;
                GetComponent<Collider2D>().enabled = false; // no collider when it needs to be destroyed
                GetComponent<SpriteRenderer>().enabled = false; // no sprite when it needs to be destroyed
                _powerUpManager.DropPowerUp(transform.position); // drop power up
            }
            Destroy(gameObject);  // destroy the block
        }
    }
}