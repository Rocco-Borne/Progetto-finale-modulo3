using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator _playerAnimator;
    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;
    private bool _isWalking;
  
    void Start()
    {
        _playerAnimator =GetComponent<Animator>();
        _playerController=GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _isWalking = _playerController._direction.magnitude != 0;
        MovementAnimations();
        SpriteFlip();
    }

    private void MovementAnimations()
    {
        _playerAnimator.SetBool("IsWalking", _isWalking);
        if (_isWalking)
        {
            _playerAnimator.SetFloat("X" , _playerController._direction.x);
        }
        else
        {
            _playerAnimator.SetFloat("X", 0);
        }
    }
    private void SpriteFlip()
    {
        if(_playerController._direction.x <0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
