using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectPieces : MonoBehaviour
{
    [SerializeField]
    Camera _camera;

    SpriteRenderer[] _spriteRenderer;
    SoundController _soundController;

    int _countInactive;
    public bool collected;
    public bool stopSpaw = false;

    [Header("HUD")]
    public TextMeshProUGUI scoreTxt;

    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        _camera = Camera.main;

        PieceScore(0);
    }

    void Update()
    {
        transform.position = new Vector3(_camera.transform.position.x - 0.3f, 0, 0);
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
                PieceScore(_countInactive);
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
        scoreTxt.text = result.ToString() + " of 12";
    }
}