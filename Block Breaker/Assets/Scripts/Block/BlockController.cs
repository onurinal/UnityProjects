using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.LevelSystem;

namespace BlockBreaker.Block
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private int _blockLife;
        [SerializeField] private Sprite[] _blockSprites;

        [SerializeField] private int _pointPerBlockDestroyed;

        private LevelManager _levelManager;
        void Start()
        {
            CountBreakableBlocks();
        }
        void Update()
        {
            
        }
        private void CountBreakableBlocks()
        {
            _levelManager = FindObjectOfType<LevelManager>();
            _levelManager.CountBreakableBlocks();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_blockLife <= 1)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextBlockSprite();
            }
        }
        private void ShowNextBlockSprite()
        {
            _blockLife--;
            int _spriteIndex = _blockLife - 1;  // _blockSprite size is 2 so when red block got hit, _spriteIndex must be "1".
            GetComponent<SpriteRenderer>().sprite = _blockSprites[_spriteIndex];
        }
        private void DestroyBlock()
        {
            _levelManager.AddToScore(_pointPerBlockDestroyed);
            Destroy(gameObject);
            _levelManager.BlockDestroyed();
        }
    }
}