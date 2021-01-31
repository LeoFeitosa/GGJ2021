﻿using System.Collections;
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
        Show();
        Hide();
        print(_collectPieces.collected);
    }


    void Show()
    {
        if (_collectPieces.collected == 2)
        {
            transparence += 0.042f;
        }
        if (_spriteRenderer.color.a >= 1)
        {
            transparence = 1;
        }

        _spriteRenderer.color = new Color(1f, 1f, 1f, transparence);
    }

    void Hide()
    {
        if (_collectPieces.collected == 1)
        {
            transparence -= 0.042f;
        }
        if (_spriteRenderer.color.a <= 0)
        {
            transparence = 0;
        }
    }
}
