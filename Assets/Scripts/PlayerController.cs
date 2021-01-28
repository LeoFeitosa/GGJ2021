using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    PlayerAnimator _playerAnimator;

    [SerializeField]
    float jumpForce = 400;

    [SerializeField]
    LayerMask layerGround;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float groundCheckRadius = 0.02f;

    [SerializeField]
    bool isGround;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            Jump();
        }

        RunAnimations();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerGround);
    }

    void RunAnimations()
    {
        _playerAnimator.SetGrounded(isGround);
        _playerAnimator.SetSpeedY(_rigidbody2D.velocity.y);
    }
}
