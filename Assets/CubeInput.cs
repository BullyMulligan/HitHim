using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CubeInput : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private int _speed = 100;

    public void FixedUpdate()
    {
        if (transform.position.y < 0)
        {
            transform.position =new Vector3(0, 3, 0);
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out var hitInfo,1000f))
        {
            if (Input.GetMouseButton(0))
            {
                var target = hitInfo.point;
                var result = (target - transform.position).normalized;
                _rigidbody.AddForce(new Vector3(result.x, 0, result.z) * _speed);

            }
            
        }
    }
}