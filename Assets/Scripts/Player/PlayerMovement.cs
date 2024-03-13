using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float _speed;

    [Header("Physics")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private ConstantForce _constantForce;
    [SerializeField] private float _gravityMultiplier;
    private const float GRAVITY = -9.81f;

    [Header("Falling")]
    [SerializeField] private Vector3 _groundColliderOffset;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundMask;


    private void FixedUpdate()
    {
        Move();

        ManageGravity();
    }

    private void ManageGravity()
    {
        if (!IsOnGround()) _constantForce.force = new Vector3(0, GRAVITY * _gravityMultiplier, 0);
        else _constantForce.force = Vector3.zero;
    }

    private void Move()
    {
        Vector3 movingDir = (
            Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward
        );

        _rb.velocity = movingDir.normalized * _speed;
    }

    private bool IsOnGround()
        => Physics.SphereCast(transform.position + _groundColliderOffset, _groundCheckRadius, -Vector3.up, out _, _groundCheckRadius, _groundMask);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + _groundColliderOffset, _groundCheckRadius);
    }
}
