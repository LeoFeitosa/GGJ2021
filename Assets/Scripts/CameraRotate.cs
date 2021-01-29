using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    Quaternion targetRotation;

    [SerializeField]
    float speedRotate = 1f;

    int angle;

    void FixedUpdate()
    {
        if (angle >= 0)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * speedRotate);
        }
    }

    public void Rotate(int position)
    {
        angle = position;

        Vector3 direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
        targetRotation = Quaternion.Euler(direction);
    }
}
