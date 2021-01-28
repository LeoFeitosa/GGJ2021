using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    [SerializeField]
    float jumpForce = 400;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
