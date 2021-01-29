using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    Camera _camera;

    //velocidade do movimento
    [SerializeField]
    float speed;

    //posiveis posicoes da camera
    [SerializeField]
    int[] positions;

    private void Start()
    {
        //pega a camera principal
        _camera = Camera.main;
    }

    void Update()
    {
        //movimenta a peca da direita para esquerda
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    //se colidir com o player o objeto é destroido
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //se colidir com o player rotaciona a camera
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
}
