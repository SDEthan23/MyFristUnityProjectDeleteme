using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private Animator _animator;
    
    public Player_SoundScript playerSoundSystem;

    public float speed = 5f;
    public float jumpForce = 5f;
    public int jumpAmount = 1;
    private int staticJumpAmount;

    public float _groundCheckDistance = 0.1f;
    private bool _isGrounded = false;
    private bool _canPlayLandSound = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        staticJumpAmount = jumpAmount ;
        
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        Bounds bounds = _collider.bounds;
        Vector2 leftRayOrigin = new Vector2(bounds.min.x, bounds.min.y);
        Vector2 rightRayOrigin = new Vector2(bounds.max.x, bounds.min.y);

        RaycastHit2D hitLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hittRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));

        _isGrounded = hitLeft.collider != null || hittRight.collider != null;
        _animator.SetBool("isJumping", !_isGrounded);

        if (_isGrounded && _canPlayLandSound)
        {
            playerSoundSystem.PlayerRandomLandSound();
            _canPlayLandSound = false;
        }
        if(!_isGrounded)
        {
            _canPlayLandSound = true;
        }
    }

    void Update()
    {
         
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(moveHorizontal * speed, _rb.velocity.y);
        if (moveHorizontal != 0)
        {
            FlipSprite(moveHorizontal);
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }



        if (jumpAmount > 0)
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpAmount = jumpAmount - 1;

            }
        }
        
        if (jumpAmount > 1)
        {
            if (Input.GetButtonDown("Jump") && !_isGrounded)
            {
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpAmount = jumpAmount - 1;
                playerSoundSystem.PlayerJumpSound();

            }
        }
        if (_isGrounded == true)
        {
            jumpAmount = staticJumpAmount;
        }


       

       











        void FlipSprite(float horizontalInput)
        {
            Vector3 scale = transform.localScale;
            scale.x = (horizontalInput > 0) ? 1 : -1;
            transform.localScale = scale;
        }

    }
}
 