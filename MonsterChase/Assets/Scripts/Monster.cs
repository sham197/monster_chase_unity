using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    
    private Rigidbody2D _rigidbody2D;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = Vector2.right * speed;
    }
}
