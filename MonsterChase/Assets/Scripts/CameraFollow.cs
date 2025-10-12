using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Transform _player;
    
    Vector3 _tempPos;
    
    [SerializeField] private float minX, maxX;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }
    
    void LateUpdate()
    {
        if (!_player)
            return;
        
        _tempPos = transform.position;
        _tempPos.x = _player.position.x;
        
        if (_tempPos.x < minX)
        {
            _tempPos.x = minX;
        }
        
        if (_tempPos.x > maxX)
        {
            _tempPos.x = maxX;       
        }
        transform.position = _tempPos;
    }
}
