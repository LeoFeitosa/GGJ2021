using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPieces : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderer;
    int _spriteRendererSize;


    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    public void HidePiece()
    {
        int index = Random.Range(0, _spriteRenderer.Length);

        if (!_spriteRenderer[index].enabled)
        {
            //HidePiece();
        }
        else
        {
            _spriteRenderer[index].enabled = false;
        }

        _spriteRendererSize += 1;

        if (_spriteRendererSize >= _spriteRenderer.Length)
        {
            return;
        }

        print(index);
    }
}
