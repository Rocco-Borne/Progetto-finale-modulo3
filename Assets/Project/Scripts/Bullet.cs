using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _lifeTime = 5;
    [SerializeField] private float _speed = 5;
    private Vector2 _dir;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
        GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController life = collision.collider.GetComponentInParent<LifeController>();

        if (life != null)
        {
            life.AddHp(-_damage);
        }

        Destroy(gameObject);
    }
    public void SetDir(Vector2 direction)
    {
        _dir = direction;
    }
}
