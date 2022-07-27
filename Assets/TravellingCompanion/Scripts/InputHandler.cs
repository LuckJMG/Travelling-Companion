using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Vector3 _playerInput;
    private bool _isRunning;
    private bool _isJumping;

    public Vector3 PlayerInput { get => _playerInput; }
    public bool IsRunning { get => _isRunning; }
    public bool IsJumping { get => _isJumping; }

    private void Update()
    {
        _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        _isRunning = Input.GetKey(KeyCode.LeftControl) == true ? true : false;
        _isJumping = Input.GetKeyDown(KeyCode.Space) == true ? true : false;
    }
}
