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

        private void Start()
        {
            CountBreakableBlocks();
        }
        private void CountBreakableBlocks()
        {
            GameManager.Instance.CountBreakableBlock(gameObject);
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
            GameManager.Instance.AddToScore(_pointPerBlockDestroyed);
            Destroy(gameObject);
            GameManager.Instance.RemoveBreakableBlock(gameObject);
        }
    }
}