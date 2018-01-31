using UnityEngine;
using System.Collections;

public class CameraRotationByMouse : MonoBehaviour
{

    public float speedH = 10.0f;
    public float speedV = 10.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
