using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private GameObject[] characters;
    
    int _charIndex;
    
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    
    private void Awake()
    {
       if (instance == null)
       { 
           instance = this;
       }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
