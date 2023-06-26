using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    
    [Header("Movement")]
    [SerializeField] private float maximumSpeed = 5f;

    [Header("Visuals")] 
    [SerializeField] private GameObject robe;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void Run()
    {
        _rigidbody2D.velocity = new Vector2(
            _movement.x * maximumSpeed,
            _movement.y * maximumSpeed);
    }

    void OnMove(InputValue inputAction)
    {
        _movement = inputAction.Get<Vector2>();
    }
}
