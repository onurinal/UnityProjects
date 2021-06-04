using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.ManagerSystem;

namespace BlockBreaker.Block
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private BlockProperties _blockProperties;
        
        [SerializeField] private int _blockLife;
        [SerializeField] private Sprite[] _blockSpriteList;
        [SerializeField] private int _pointPerBlockDestroyed;
        [SerializeField] private GameObject _breakParticlePrefab;

        private SpriteRenderer _blockSprite;
        private bool _isBlockAlive = true;  
        
        // FOR BLOCK HIT ANIMATION
        private float _currentBlockSize;
        private float _goalBlockSize;

        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private PowerUpManager _powerUpManager;
        private void Start()
        {
            AccessingObjects();
            CountBreakableBlocks();
        }
        private void AccessingObjects()
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
                StartCoroutine(StartBlockHitAnimation());
                ShowNextBlockSprite();
            }
        }
        private void ShowNextBlockSprite()
        {
            int _spriteIndex = _blockLife - 1;  // _blockSprite size is 2 so when red block got hit, _spriteIndex must be "1".
            _blockSprite.sprite = _blockSpriteList[_spriteIndex];
        }
        private void DestroyBlock()
        {
            _gameManager.RemoveBreakableBlock(gameObject); // remove block in list
            // Sometimes balls hit same block at the same time. That is why we need to use bool variable for fix
            if (_isBlockAlive)
            {
                _scoreManager.AddToScore(_pointPerBlockDestroyed); // add points each block
                _isBlockAlive = false;
                GetComponent<Collider2D>().enabled = false; // no collider when it needs to be destroyed
                GetComponent<SpriteRenderer>().enabled = false; // no sprite when it needs to be destroyed
                Instantiate(_breakParticlePrefab, transform.position, Quaternion.identity); // create particle when block has no life
                _powerUpManager.DropPowerUp(transform.position); // drop power up
            }
            Destroy(gameObject);  // destroy the block
        }
        // ----------------------- BLOCK HIT ANIMATION MANAGEMENT ---------------
        IEnumerator ExtendBlockSize()
        {
            // Just take the current x size because we are extending x and y sizes equally. That is why we don't need to know y size of the block.
            _currentBlockSize = transform.localScale.x;
            _goalBlockSize = _blockProperties.ExtendSquareBlockSize;
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
            _goalBlockSize = _blockProperties.ShrinkSquareBlockSize;
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