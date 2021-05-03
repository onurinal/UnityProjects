using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.ManagerSystem;

namespace BlockBreaker.Block
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private int _blockLife;
        [SerializeField] private Sprite[] _blockSprites;

        [SerializeField] private int _pointPerBlockDestroyed;

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
        }

        private void CountBreakableBlocks()
        {
            _gameManager.CountBreakableBlock(gameObject);
        }
        public void TakeDamage()
        {
            _blockLife--;
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
            GetComponent<SpriteRenderer>().sprite = _blockSprites[_spriteIndex];
        }
        private void DestroyBlock()
        {
            _gameManager.RemoveBreakableBlock(gameObject); // remove block in list
            _scoreManager.AddToScore(_pointPerBlockDestroyed); // add points each block
            _powerUpManager.DropPowerUp(transform.position); // drop power up
            Destroy(gameObject);  // destroy the block
        }
    }
}