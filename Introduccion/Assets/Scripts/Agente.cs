using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{
    public Vector3 goal; // Meta, esfera
    public float speed;

    public bool enMeta;
    void Update()
    {
        enMeta = false;
        Vector3 p1 = goal;
        Vector3 p2 = transform.position ;
        Vector3 dir = p1 - p2;

        if (dir.magnitude > 0.5f) 
        {
            transform.position = transform.position + speed*dir.normalized;
        } 
        else 
        {
            enMeta = true;
        }
    }
}
