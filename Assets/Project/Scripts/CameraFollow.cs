using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _Player;
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_Player.position.x,_Player.position.y, -10);
    }

}
