using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _dmg = 5;
    [SerializeField] float _speed = 4f;
    private GameObject _player;
    Rigidbody2D _rb;
    public Vector2 _dir;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _dir = (_player.transform.position - _rb.transform.position).normalized;
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(Vector2.MoveTowards(_rb.transform.position, _player.transform.position, _speed*Time.deltaTime));
        
    }
    private void OnCollision2D(Collision2D collision)
    {
        LifeController life= collision.collider.GetComponentInParent<LifeController>();
        if (life != null )
        {
            life.AddHp(-_dmg);
        }
        gameObject.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
