using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] float _fireRate = 0.5f;
    [SerializeField] int _fireRange = 10;
    private float timer=0;
    private float Dist = 10000;
    [SerializeField] private GameObject Bullet;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        if (Dist < 10)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            
        }
    }
    public GameObject FindNearestEnemy()
    {
        Dist = 10000;
        GameObject nearestEnemy;
        GameObject [] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i=0; i < _enemies.Length; i++)
        {
            float distX =  (transform.position.x - _enemies[i].transform.position.x );
            float distY = (transform.position.y - _enemies[i].transform.position.y);
            Vector2 dir= new Vector2(distX, distY);
            float Distance = dir.magnitude;
            if (Distance < Dist)
            {
                Dist = Distance;
                nearestEnemy = _enemies[i];
            }
        }

        return nearestEnemy;
    }

}
