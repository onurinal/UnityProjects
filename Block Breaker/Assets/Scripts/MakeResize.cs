using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeResize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _gameplayBackground;
    [SerializeField] private SpriteRenderer _topCollider;
    [SerializeField] private Transform _rightCollider;
    [SerializeField] private Transform _leftCollider;
    private float _worldScreenWidth;
    private float _worldScreenHeight;
    private void Awake()
    {
        // ----------------------- RESIZE GAMEPLAY BACKGROUND TO ASPECT RATIO ---------------
        _worldScreenHeight = Camera.main.orthographicSize * 2f;
        _worldScreenWidth = _worldScreenHeight / Screen.height * Screen.width;

        // _gameplayBackground.sprite.bounds.size.x,  GET THE SPRITE SIZES X AND Y
        // _gameplayBackground.sprite.bounds.size.y,
    
        _gameplayBackground.transform.localScale = new Vector3
            (_worldScreenWidth / _gameplayBackground.sprite.bounds.size.x,
             _worldScreenHeight / _gameplayBackground.sprite.bounds.size.y,
             _gameplayBackground.transform.localScale.z);
        // ----------------------- RESIZE GAMEPLAY BACKGROUND TO ASPECT RATIO ---------------
        _topCollider.transform.localScale = new Vector3(_worldScreenWidth / _topCollider.sprite.bounds.size.x,
                                                        _topCollider.transform.localScale.y,
                                                        _topCollider.transform.localScale.z);
        // ----------------------- REPOSITIONING COLLIDER TO ASPECT RATIO ---------------
        _rightCollider.transform.position = new Vector3(_worldScreenWidth / 2 + 0.5f,
                                                        _rightCollider.transform.position.y,
                                                        _rightCollider.transform.position.z);
        _leftCollider.transform.position = new Vector3(-(_worldScreenWidth / 2 + 0.5f),
                                                       _leftCollider.transform.position.y,
                                                       _leftCollider.transform.position.z);
    }
}
