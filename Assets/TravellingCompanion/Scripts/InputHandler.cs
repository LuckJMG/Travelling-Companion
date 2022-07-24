using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Vector2 _playerInput;
    private bool _isRunning;
    private bool _isJumping;

    public Vector2 PlayerInput { get => _playerInput; }
    public bool IsRunning { get => _isRunning; }
    public bool IsJumping { get => _isJumping; }

    private void Update()
    {
        _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _isRunning = Input.GetKey(KeyCode.LeftControl) == true ? true : false;
        _isJumping = Input.GetKeyDown(KeyCode.Space) == true ? true : false;
    }
}
