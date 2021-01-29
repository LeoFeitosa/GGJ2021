using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPieces : MonoBehaviour
{
    List<SpriteRenderer> cells = new List<SpriteRenderer>();
    SpriteRenderer[] _spriteRenderer;
    SpriteRenderer[] _spriteRendererInactive;
    int _countInactive;


    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
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
            }
        }
    }
}
