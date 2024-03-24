using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] private Vector3 _cameraOffsetFromPlayerCenter;
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _cameraOffsetFromPlayerCenter;
    }
}
