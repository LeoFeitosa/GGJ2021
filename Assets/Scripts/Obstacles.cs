using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    PlayerController _playerController;
    SpriteRenderer _spriteRenderer;

    //velocidade do movimento
    [SerializeField]
    float speed;

    Vector3 direction = Vector3.zero;

    void Start()
    {
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //movimenta o obstaculo da direita para esquerda
        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.Damage();
            //destroi a peca que colidiu
            Destroy(this.gameObject);
        }
    }

    private void Flip()
    {
        // direcao da obstaculo
        if (_playerController.isLookLeft)
        {
            direction = Vector3.right;
            transform.position += direction * speed * Time.deltaTime;
            _spriteRenderer.flipX = false;
        }
        if(!_playerController.isLookLeft)
        {
            direction = Vector3.right;
            transform.position -= direction * speed * Time.deltaTime;
            _spriteRenderer.flipX = true;
        }
    }
}
