using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalController : MonoBehaviour
{

    SpriteRenderer imageFinal;
    CollectPieces _collectPieces;

    float transparence = 0;
    float timer;

    void Start()
    {
        _collectPieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;

        imageFinal = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_collectPieces.stopSpaw)
        {
            transparence += 0.005f;
            imageFinal.color = new Color(1f, 1f, 1f, transparence);

            if (transparence >= 1)
            {
                transparence = 1;
            }
        }


        if(transparence >= 1)
        {
            timer += Time.deltaTime;
        }

        if (timer > 20)
        {
            SceneManager.LoadScene("Menu");
        }
    }


}
