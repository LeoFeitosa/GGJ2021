using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScenery : MonoBehaviour
{
    //velocidade da imagem
    [SerializeField]
    float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
