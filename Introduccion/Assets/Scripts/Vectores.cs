using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour
{
    public GameObject goal;
    void Start()
    {

    }

    void Update()
    {
        Vector3 p1 = goal.transform.position;
        Vector3 p2 = transform.position;
        Vector3 orientation = new Vector3(p1.x-p2.x, p1.z-p2.y, 0);
        transform.Translate(0.02f*orientation.normalized);
    }
}
