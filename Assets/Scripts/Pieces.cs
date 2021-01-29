using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    Camera _camera;
    PlayerController _playerController;
    InfiniteScenery _infiniteScenery;
    SpawPieces _spawPieces;

    //velocidade do movimento
    [SerializeField]
    float speed;

    //posiveis posicoes da camera
    [SerializeField]
    int[] positions;

    Vector3 direction = Vector3.zero;

    private void Start()
    {
        //pega a camera principal
        _camera = Camera.main;
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _infiniteScenery = FindObjectOfType(typeof(InfiniteScenery)) as InfiniteScenery;
        _spawPieces = FindObjectOfType(typeof(SpawPieces)) as SpawPieces;
    }

    void Update()
    {
        //movimenta a peca da direita para esquerda
        Flip();
    }

    //se colidir com o player o objeto é destroido
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.Flip();
            _infiniteScenery.Flip();

            //rotaciona a camera
            RotateRandom();

            //destroi a peca que colidiu
            Destroy(this.gameObject);
        }
    }

    private void RotateRandom()
    {
        //pega um numero qualquer dos que estão preechidos
        int position = positions[Random.Range(0, positions.Length)];
        _camera.transform.Rotate(new Vector3(0, 0, position));
    }

    private void Flip()
    {
        // direcao da peca
        if (_playerController.isLookLeft)
        {
            direction = Vector3.right;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            direction = Vector3.right;
            transform.position -= direction * speed * Time.deltaTime;
        }
    }
}
