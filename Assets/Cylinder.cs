using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private int _countCylinder = 6;
    [SerializeField] private GameObject _spfere;
    [SerializeField] private GameObject _cube;


    // Start is called before the first frame update
    public Color[] colors = { Color.blue, Color.red, Color.green};
    void Start()
    {
        _cube.GetComponent<Renderer>().material.color = colors[Random.Range(0, 3)];
        for (int i = 0; i < _countCylinder; i++)
        {
            NewCylinder();
        }
        NewSphere();
        

    }

    private void NewCylinder()
    {
        var cylinder = Instantiate(_cylinder);
        var cylinderColor = cylinder.GetComponent<Renderer>();
        _cylinder.transform.position = new Vector3(Random.Range(-40,40),2,Random.Range(-40,40));
        cylinderColor.material.color = colors[Random.Range(0,3)];
        
    }

    private void  NewSphere()
    {
        var sphere = Instantiate(_spfere);
        sphere.transform.position = new Vector3(Random.Range(-40, 10), 2, Random.Range(-40, 40));
        sphere.GetComponent<Renderer>().material.color = colors[Random.Range(0, 3)];
    }
}
