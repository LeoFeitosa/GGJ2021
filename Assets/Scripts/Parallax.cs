using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField]
    float moveSpeed = 1f;

    [SerializeField]
    float offset;
    private Vector2 startPosition;
    private float newXposition;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isLookLeft)
        {
            newXposition = Mathf.Repeat(Time.time * moveSpeed, offset);
        }
        else
        {
            newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        }

        transform.position = startPosition + Vector2.right * newXposition;
    }
}
