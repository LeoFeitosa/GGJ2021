using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    Quaternion targetRotation;

    [SerializeField]
    float speedRotate = 1f;

    [SerializeField]
    Transform Xpositive;

    [SerializeField]
    Transform Xnegavite;

    int angle;
    bool invert;

    void Start()
    {
        transform.position = Xpositive.position;
    }

    void FixedUpdate()
    {
        if (angle >= 0)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * speedRotate);
        }

        if (invert)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * speedRotate * 2.5f, transform.position.y, transform.position.z);
            if (transform.position.x < -10)
            {
                transform.position = new Vector3(-10, 0.1f, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speedRotate * 2.5f, transform.position.y, transform.position.z);
            if (transform.position.x >= 0)
            {
                transform.position = new Vector3(0, 0.1f, transform.position.z);
            }
        }
    }

    public void Rotate(int position)
    {
        int rand = Random.Range(0, 100);

        angle = position;

        Vector3 direction = Vector3.zero;

        if (rand % 2 == 0)
        {
            direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
            targetRotation = Quaternion.Euler(direction * -1);
        }
        else
        {
            direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
            targetRotation = Quaternion.Euler(direction);
        }
    }

    public void Invert(bool Xinvert)
    {
        invert = Xinvert;
    }
}
