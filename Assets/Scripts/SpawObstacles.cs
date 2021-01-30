using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObstacles : MonoBehaviour
{
    PlayerController _playerController;
    CollectPieces _collectPieces;

    [SerializeField]
    GameObject obstacle1;

    [SerializeField]
    GameObject obstacle2;

    [SerializeField]
    GameObject obstacle3;

    GameObject obstacleCurrent;

    [SerializeField]
    float height;

    [SerializeField]
    float maxTime = 2f;

    [SerializeField]
    float destroyTime = 6f;

    float timer = 0f;

    void Start()
    {
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _collectPieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("GetObstacle", 2);
    }

    void GetObstacle()
    {
        if (timer > maxTime && !_collectPieces.stopSpaw)
        {
            int rand = Random.Range(0, 4);
            if (rand == 1)
            {
                obstacleCurrent = Instantiate(obstacle1);
            }
            if (rand == 2)
            {
                obstacleCurrent = Instantiate(obstacle2);
            }
            else
            {
                obstacleCurrent = Instantiate(obstacle3);
            }

            obstacleCurrent.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            //verifica o lado do player para definir o lado da instancia
            if (_playerController.isLookLeft)
            {
                obstacleCurrent.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                obstacleCurrent.transform.position = new Vector3(-obstacleCurrent.transform.position.x, obstacleCurrent.transform.position.y, obstacleCurrent.transform.position.z);
            }

            //destroi o objeto depois de um tempo
            Destroy(obstacleCurrent, destroyTime);

            //zera a contagem
            timer = 0;
        }

        //soma a contagem
        timer += Time.deltaTime;
    }
}
