using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 10f;

    private Vector2 _moveInput;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Animator _anim;
    
    private string WALK_ANIMATION = "walk";
    private void Awake()
    {
    }

    void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log(_moveInput);
    }
    
    void MovePlayerKeyboard()
    {
        transform.position += new Vector3(_moveInput.x, 0f, 0f) * moveForce * Time.deltaTime;
    }
    void Update()
    {
        MovePlayerKeyboard();
    }
}