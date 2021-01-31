using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    PlayerController _playerController;
    SpriteRenderer _spriteRenderer;
    CollectPieces _collectPieces;

    //velocidade do movimento
    [SerializeField]
    float speed;

    Vector3 direction = Vector3.zero;

    void Start()
    {
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collectPieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;
    }

    void Update()
    {
        if (transform.position.x < 10)
        {
            _spriteRenderer.flipX = true;
        }
        if (transform.position.x > -10)
        {
            _spriteRenderer.flipX = false;
        }

        //movimenta o obstaculo da direita para esquerda
        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.Damage();
            _collectPieces.ShowPiece();
            //destroi a peca que colidiu
            Destroy(this.gameObject);
        }
    }

    void Flip()
    {
        // direcao da obstaculo
        if (_playerController.isLookLeft)
        {
            direction = Vector3.right;
            transform.position += direction * speed * Time.deltaTime;
        }
        if(!_playerController.isLookLeft)
        {
            direction = Vector3.right;
            transform.position -= direction * speed * Time.deltaTime;
        }
    }
}
