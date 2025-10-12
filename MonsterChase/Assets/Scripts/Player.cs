using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] float moveForce = 5f;
    
    [SerializeField] float jumpForce = 10f;

    Vector2 _moveInput;
    
    Rigidbody2D _rigidbody2D;
    
    SpriteRenderer _spriteRenderer;
    
    Animator _anim;
    
    PlayerInput _playerInput;
    
    bool _isGrounded = true;
    
    string _groundTag = "Ground";
    
    string ENEMY_TAG = "Monster";
    
    string _walkAnimation = "Walk";
    
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        
        // Подписка на события
        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnMove;
        
        _playerInput.Player.Jump.performed += OnJump;
    }
    
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnDestroy()
    {
        // Отписка от событий
        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Move.canceled -= OnMove;
        _playerInput.Player.Jump.performed -= OnJump;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }
    
    void Update()
    {
        AnimatePlayer();
    }
    void FixedUpdate()
    {
        MovePlayerPhysics();
    }

    void MovePlayerPhysics()
    {
        _rigidbody2D.linearVelocity = new Vector2(_moveInput.x * moveForce, _rigidbody2D.linearVelocity.y);
    }
    
    void AnimatePlayer()
    {
        if (_moveInput.x > 0)
        {
            _anim.SetBool(_walkAnimation, true);
            _spriteRenderer.flipX = false;
        }
        else if (_moveInput.x < 0)
        {
            _anim.SetBool(_walkAnimation, true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _anim.SetBool(_walkAnimation, false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_groundTag))
        {
            _isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}