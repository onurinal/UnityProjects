using UnityEngine;

namespace BlockBreaker.Block
{
    public abstract class BaseBlock : MonoBehaviour
    {
        [SerializeField] protected int blockLife;
        [SerializeField] protected int pointPerBlockDestroyed;

        [SerializeField] protected GameObject breakParticlePrefab;

        protected bool isBlockAlive = true;
        
        public abstract void TakeDamage(int damage);
    }
}

