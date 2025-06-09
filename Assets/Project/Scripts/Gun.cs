using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] float _fireRate = 0.5f;
    [SerializeField] float _fireRange = 10f;
    private float timer = 0f;
    private float Dist;
    [SerializeField]private Bullet Bullet;



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
        Enemy enemy =FindNearestEnemy();
        if (Dist < _fireRange)
        {
            Bullet clone = Instantiate(Bullet, transform.position, transform.rotation);
            clone.SetDir((enemy.transform.position-transform.position).normalized);
        }
    }
    public Enemy FindNearestEnemy()
    {
        Dist = 10000f;
        Enemy nearestEnemy=null;
        Enemy [] _enemies = Transform.FindObjectsOfType<Enemy>();
        for (int i=0; i < _enemies.Length; i++)
        {
            float Distance = (transform.position-_enemies[i].transform.position).magnitude;
            if (Distance < Dist)
            {
                Dist = Distance;
                nearestEnemy = _enemies[i];
            }
        }

        return nearestEnemy;
    }

}
