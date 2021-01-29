using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPieces : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderer;
    SpriteRenderer[] _spriteRendererActive;

    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _spriteRendererActive = GetComponentsInChildren<SpriteRenderer>();
    }

    public void HidePiece()
    {
        /*for (int i = 0; i <= _spriteRenderer.Length - 1; i++)
        {
            if (_spriteRenderer[i].enabled)
            {
                _spriteRendererActive[i] = _spriteRenderer[i];
            }
        }*/

        int index = Random.Range(0, _spriteRendererActive.Length);
        _spriteRenderer[index].enabled = false;
        print(index);

        /*for (int i = 0; i <= _spriteRendererActive.Length - 1; i++)
        {
            if (_spriteRenderer[index].enabled && _spriteRendererActive[i] != _spriteRenderer[index])
            {
                _spriteRenderer[i].enabled = false;
                _spriteRendererActive[i] = _spriteRenderer[i];
            }
        }*/
    }
}
