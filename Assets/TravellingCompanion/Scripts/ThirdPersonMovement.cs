using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private Transform _transform;
    private InputHandler _inputHandler;
    private CharacterController _characterController;
    private float _turnSmoothVelocity;

    private void Awake()
    {
        _transform = transform;
        _inputHandler = GetComponent<InputHandler>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        playerCamera = playerCamera != null ? playerCamera : Camera.main.transform;
    }

    private void Update()
    {
        if (_inputHandler == null || _characterController == null) return;

        Move();
    }

    private void Move()
    {
        var direction = _inputHandler.PlayerInput.normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float currentAngle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            _transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
            _characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
