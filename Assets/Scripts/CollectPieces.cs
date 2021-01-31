using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPieces : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderer;
    SoundController _soundController;

    int _countInactive;
    public bool collected;
    public bool stopSpaw = false;

    [Header("HUD")]
    public Text scoreTxt;
    public int score;

    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;

        scoreTxt.text = score.ToString() + " de 12";
    }

    void Update()
    {
        //collected = false;
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
                _soundController.EffectSound("Piece");
                _spriteRenderer[index].enabled = false;
                _countInactive++;
                collected = true;
                PieceScore(1);
                StartCoroutine(DisableCollected());
            }
        }

        if (_countInactive == _spriteRenderer.Length)
        {
            stopSpaw = true;
        }
    }

    IEnumerator DisableCollected()
    {
        yield return new WaitForSeconds(0.01f);
        collected = false;
    }

    public void PieceScore(int result)
    {
        if(result == 1)
        {
            score += 1;
            scoreTxt.text = score.ToString() + " de 12";
        } else if (result == 2) 
        {
            score -= 1;
            scoreTxt.text = score.ToString() + " de 12";
        }
    }

}