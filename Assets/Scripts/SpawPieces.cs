using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPieces : MonoBehaviour
{
    [SerializeField]
    GameObject piece;

    [SerializeField]
    float height;

    [SerializeField]
    float maxTime = 2f;

    [SerializeField]
    float destroyTime = 6f;

    float timer = 0f;

    void Start()
    {
        //cria uma nova instanica da peca
        GameObject newPiece = Instantiate(piece);

        //modifica randomicamenta a altura da peca Y
        newPiece.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            //cria uma nova instanica da peca
            GameObject newPiece = Instantiate(piece);

            //modifica randomicamenta a altura da peca Y
            newPiece.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            
            //destro o objeto depois de um tempo
            Destroy(newPiece, destroyTime);

            //zera a contagem
            timer = 0;
        }

        //soma a contagem
        timer += Time.deltaTime;
    }
}
