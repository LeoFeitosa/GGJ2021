using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetGrounded(bool input)
    {
        _animator.SetBool("isGrounded", input);
    }
    public void SetSpeedY(float input)
    {
        _animator.SetFloat("speedY", input);
    }
}
