using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    //velocidade do movimento
    [SerializeField]
    float speed;

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
            Destroy(this.gameObject);
        }
    }
}
