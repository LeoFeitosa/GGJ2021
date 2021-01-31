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
    PlayerController _playerController;

    int _countInactive;
    public int collected;
    public bool stopSpaw = false;

    [Header("HUD")]
    public TextMeshProUGUI scoreTxt;

    void Start()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _camera = Camera.main;

        stopSpaw = false;

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
                _playerController.Flip();
                _soundController.EffectSound("Piece");
                _spriteRenderer[index].enabled = false;
                _countInactive++;
                PieceScore(_countInactive);
                StartCoroutine(DisableCollected());
            }
        }

        if (_countInactive == _spriteRenderer.Length)
        {
            stopSpaw = true;

            _soundController.SceneMusic("Final");
            _soundController.ChangeVolumeMusic(2f);
            _playerController.Stop();
        }
    }

    IEnumerator DisableCollected()
    {
        collected = 1;
        yield return new WaitForSeconds(0.03f);
        collected = 0;
    }

    public void ShowPiece()
    {
        if (_countInactive > 0)
        {
            int index = Random.Range(0, _spriteRenderer.Length);

            if (!_spriteRenderer[index].enabled)
            {
                _spriteRenderer[index].enabled = true;
                _countInactive--;
                PieceScore(_countInactive);
                StartCoroutine(EnableCollected());
            }
            else
            {
                ShowPiece();
            }
        }
    }

    IEnumerator EnableCollected()
    {
        collected = 2;
        yield return new WaitForSeconds(0.03f);
        collected = 0;
    }

    public void PieceScore(int result)
    {
        scoreTxt.text = result.ToString() + " of 12";
    }
}