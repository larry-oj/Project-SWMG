using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = transform.GetChild(0).GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
