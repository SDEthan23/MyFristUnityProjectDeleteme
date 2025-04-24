using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContraller : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private Animator _animator;

    public float speed = 5f;
    public float jumpForce = 5f;
    public int maxJump = 2;
    public int nJump = 0;

    private float _groundCheckDistasce = 0.1f;
    private bool _isGrounded = false;
    private Vector2 rightRayOrigin;
    private float _groundCheckDistance = 0.1f;

    [SerializeField] private AudioClip jumpSound;
    private AudioSource _audioSource;
    private bool _canPlayLandSound;
    private object playerSoundSystem;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _collider = gameObject.GetComponent<Collider2D>();
        _animator = gameObject.GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
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
        RaycastHit2D hitRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, _groundCheckDistasce, LayerMask.GetMask("Ground"));
        _isGrounded = hitLeft.collider != null || hitRight.collider != null;
        _animator.SetBool("IsJumping", !_isGrounded); // * 수정
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(moveHorizontal * speed, _rb.velocity.y); // * 수정
        if (moveHorizontal != 0)
        {
            FlipSprite(moveHorizontal);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }

        if (nJump > 0)
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                PerformJump();
            }
        }

        if (nJump > 0)
        {
            if (Input.GetButtonDown("Jump") && !_isGrounded)
            {
                PerformJump();
            }
        }

        if (_isGrounded)
        {
            nJump = maxJump;
        }

        if (_isGrounded && _canPlayLandSound)
        {
            playerSoundSystem.PlayerRandomLandSound();
            _canPlayLandSound = false;
        }
    }

    private void PerformJump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        nJump--;

        if (jumpSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(jumpSound);
        }
    }

    void FlipSprite(float horizontalInput)
    {
        Vector3 scale = transform.localScale;
        scale.x = (horizontalInput > 0) ? 1 : -1;
        transform.localScale = scale;
    }
}