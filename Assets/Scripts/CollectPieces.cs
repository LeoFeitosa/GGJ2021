using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPieces : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderer;
    int _countInactive;
    public bool collected;

    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        collected = false;
    }

    public void HidePiece()
    {
        if (_countInactive < _spriteRenderer.Length)
        {
            int index = Random.Range(0, _spriteRenderer.Length);

            if (!_spriteRenderer[index].enabled)
            {
                HidePiece();
            }
            else
            {
                _spriteRenderer[index].enabled = false;
                _countInactive++;
                collected = true;
            }
        }
    }
}
