using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.LevelSystem;

namespace BlockBreaker.Block
{
    public class BlockController : MonoBehaviour
    {
        private LevelManager _levelManager;
        void Start()
        {
            _levelManager = FindObjectOfType<LevelManager>();
            _levelManager.CountBreakableBlocks();
        }

        void Update()
        {

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            DestroyBlock();
        }

        private void DestroyBlock()
        {
            _levelManager.AddToScore();   // Testing... After testing do 3 function for score ( Red, orange and green block)
            Destroy(gameObject);
            _levelManager.BlockDestroyed();
        }
    }

}