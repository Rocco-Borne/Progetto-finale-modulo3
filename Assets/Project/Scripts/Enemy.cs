using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _dmg = 5;
    [SerializeField] float _speed = 4f;
    private GameObject _player;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(Vector2.MoveTowards(_rb.transform.position, _player.transform.position, _speed*Time.deltaTime));
    }
}
