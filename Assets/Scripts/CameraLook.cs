using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Vector2 _sensitivity;
    [SerializeField] private Transform _player;
    private float xRotarion = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity.y * Time.deltaTime;

        xRotarion -= mouseY;
        xRotarion = Mathf.Clamp(xRotarion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotarion, 0, 0);
        _player.Rotate(Vector3.up * mouseX);
    }
}
