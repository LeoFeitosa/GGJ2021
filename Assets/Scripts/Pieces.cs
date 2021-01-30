using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    PlayerController _playerController;
    CameraRotate _cameraRotate;
    CollectPieces _collectPieces;
    SoundController _soundController;

    //velocidade do movimento
    [SerializeField]
    float speed;

    //posiveis posicoes da camera
    [SerializeField]
    int[] positions;

    Vector3 direction = Vector3.zero;

    private void Start()
    {
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _cameraRotate = FindObjectOfType(typeof(CameraRotate)) as CameraRotate;
        _collectPieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
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
            _collectPieces.HidePiece();

            //rotaciona a camera
            RotateRandom();

            //destroi a peca que colidiu
            Destroy(this.gameObject);
        }
    }

    private void RotateRandom()
    {
        _soundController.EffectSound("Rotate");

        //pega um numero qualquer dos que estão preechidos
        int position = positions[Random.Range(0, positions.Length)];

        //rotaciona a camera
        _cameraRotate.Rotate(position);

        if (_collectPieces.stopSpaw)
        {
            StartCoroutine(PositionCamereDefault());
        }
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

    IEnumerator PositionCamereDefault()
    {
        _cameraRotate.Rotate(0);
        yield return new WaitForSeconds(4f);
    }
}