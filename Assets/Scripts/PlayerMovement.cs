using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        Vector3 movingDir = (
            Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward
        );

        _rb.velocity = movingDir.normalized * _speed;
    }
}
