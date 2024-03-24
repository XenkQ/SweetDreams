using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Vector2 _sensitivity;
    private Transform _player;
    private float xRotarion = 0f;
    private Vector3 _cameraOffsetFromPlayerCenter;
    [SerializeField] private CameraPositioner _positioner;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity.y * Time.deltaTime;

        xRotarion -= mouseY;
        xRotarion = Mathf.Clamp(xRotarion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotarion, 0, 0);
        _positioner.transform.Rotate(Vector3.up * mouseX);
        _player.rotation = _positioner.transform.rotation;
    }
}