using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float walkingSpeed = 6f;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private Transform _transform;
    private InputHandler _inputHandler;
    private Rigidbody _rigidbody;
    private float _turnSmoothVelocity;

    private void Awake()
    {
        _transform = transform;
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerCamera = playerCamera != null ? playerCamera : Camera.main.transform;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var direction = _inputHandler.InputDirection;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float currentAngle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            _rigidbody.MoveRotation(Quaternion.Euler(0f, currentAngle, 0f));

            var currentSpeed = _inputHandler.IsRunning ? runningSpeed : walkingSpeed;
            Vector3 moveVelocity = _transform.forward * currentSpeed;
            _rigidbody.MovePosition(_rigidbody.position + moveVelocity * Time.deltaTime);
        }
    }
}
