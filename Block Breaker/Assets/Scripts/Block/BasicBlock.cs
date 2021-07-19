using System.Collections;
using System.Collections.Generic;
using BlockBreaker.Block;
using BlockBreaker.DestroySystem;
using BlockBreaker.ManagerSystem;
using UnityEngine;

namespace BlockBreaker.Block
{
    public class BasicBlock : BaseBlock, Destructible
    {
        [SerializeField] private BlockProperties _blockProperties;
        
        [SerializeField] private Sprite[] _blockSpriteList;
        private SpriteRenderer _blockSprite;
        
        // FOR BLOCK HIT ANIMATION
        private float _currentBlockSize;
        private float _goalBlockSize;
        
        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private void Start()
        {
            AccessObjects();
            _gameManager.CountBreakableBlock(gameObject);
        }
        private void AccessObjects()
        {
            _gameManager = GameManager.Instance;
            _scoreManager = ScoreManager.Instance;
            _blockSprite = GetComponent<SpriteRenderer>();
        }
        public override void TakeDamage(int damage)
        {
                blockLife = blockLife - damage;
                if (blockLife <= 0)
                {
                    DestroyBlock();
                }
                else
                {
                    StartCoroutine(StartBlockHitAnimation());
                    ShowNextBlockSprite();
                }
        }
        private void ShowNextBlockSprite()
        {
            int _spriteIndex = blockLife - 1;  // _blockSprite size is 2 so when red block got hit, _spriteIndex must be "1".
            _blockSprite.sprite = _blockSpriteList[_spriteIndex];
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
            }
            _gameManager.RemoveBreakableBlock(gameObject); // remove block in list
            Destroy(gameObject);  // destroy the block
        }
        // ----------------------- BLOCK HIT ANIMATION MANAGEMENT ---------------
        IEnumerator ExtendBlockSize()
        {
            // Just take the current x size because we are extending x and y sizes equally. That is why we don't need to know y size of the block.
            _currentBlockSize = transform.localScale.x;
            _goalBlockSize = _blockProperties.ExtendBlockSize;
            while (_currentBlockSize < _goalBlockSize)
            {
                _currentBlockSize += Time.deltaTime * _blockProperties.ScaleBlockSpeed;
                transform.localScale = new Vector3(_currentBlockSize, _currentBlockSize, transform.localScale.z);
                yield return null;
            }
        }
        IEnumerator ShrinkBlockSize()
        {
            // Just take the current x size because we are extending x and y sizes equally. That is why we don't need to know y size of the block.
            _currentBlockSize = transform.localScale.x;
            _goalBlockSize = _blockProperties.ShrinkBlockSize;
            while (_currentBlockSize > _goalBlockSize)
            {
                _currentBlockSize -= Time.deltaTime * _blockProperties.ScaleBlockSpeed;
                transform.localScale = new Vector3(_currentBlockSize, _currentBlockSize, transform.localScale.z);
                yield return null;
            }
        }
        IEnumerator StartBlockHitAnimation()
        {
            yield return ShrinkBlockSize(); // first shrink the block and when finish then run the below code
            yield return ExtendBlockSize();
        }
    }
}
