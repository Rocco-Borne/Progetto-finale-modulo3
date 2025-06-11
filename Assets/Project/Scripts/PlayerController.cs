using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed=3f ;
    private float horizontal;
    private float vertical;
    public Vector2 _direction;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        _direction = new Vector2(horizontal, vertical);
    }
    private void FixedUpdate()
    {

        _rb.velocity = _direction*_speed;
    }
}
