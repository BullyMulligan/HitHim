using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCollider : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphere;

    [SerializeField] private Rigidbody _cube;
    public Color[] colors = { Color.blue, Color.red, Color.green };

    //[SerializeField] private Rigidbody _cylinder;
    // Start is called before the first frame update
    public void Start()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cylinder"))
        {
            var color = collision.gameObject.GetComponent<Renderer>();
            if (color.material.color == _cube.GetComponent<Renderer>().material.color)
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("sphere"))
        {
            _cube.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("sphere"))
            {
                var sphere = Instantiate(collision.gameObject);
                sphere.transform.position = new Vector3(Random.Range(-40, 10), 2, Random.Range(-40, 40));
                sphere.GetComponent<Renderer>().material.color = colors[Random.Range(0, 3)];
            }
        }

    }

    
// Update is called once per frame
    void Update()
    {
        
    }
}