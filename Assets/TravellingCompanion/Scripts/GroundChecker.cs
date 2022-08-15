using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float groundRayLength;
    [SerializeField] private LayerMask groundLayer;
    private Transform _transform;
    private bool _isGrounded;

    public bool IsGrounded { get => _isGrounded; }

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        _isGrounded = Physics.Raycast(_transform.position, Vector3.down, groundRayLength, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * groundRayLength);
    }
}
