using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistController : MonoBehaviour
{
    CollectPieces _collectPieces;
    SpriteRenderer _spriteRenderer;
    float transparence;

    void Start()
    {
        _collectPieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        transparence = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_collectPieces.collected)
        {
            transparence -= 0.08f;
        }
        if (transparence <= 0)
        {
            transparence = 0;
        }

        _spriteRenderer.color = new Color(1f, 1f, 1f, transparence);
    }
}
