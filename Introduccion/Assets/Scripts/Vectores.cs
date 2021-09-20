using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour
{
    public GameObject goal; // Meta, esfera
    public float speed;

    void Update()
    {
        Vector3 p1 = goal.transform.position;
        Vector3 p2 = transform.position ;
        Vector3 dir = p1 - p2;

        Vector3 a = transform.right;
        Vector3 b = goal.transform.right;
        Debug.DrawRay(p1,2*b,Color.red);
        Debug.DrawRay(p2,2*a,Color.red);
        if(dir.magnitude > 0.5f) 
        {
            transform.position = transform.position + speed*dir.normalized;
        }
        //float dot = a.x*b.x + a.y*b.y + a.z* b.z;
        float theta = Mathf.Acos(Vector3.Dot(a,b)/(a.magnitude * b.magnitude));
        Debug.Log("Ángulo entre los vectores :" + Mathf.Rad2Deg*theta);
        Vector3 cross = Vector3.Cross(a, b);

        if(Mathf.Rad2Deg * theta > 5) 
        {
            float deltad = 40f;
            if(cross.y > 0) 
            {
                transform.Rotate(0, Mathf.Deg2Rad*deltad, 0);
            }
            else
            {
                transform.Rotate(0, -Mathf.Deg2Rad*deltad, 0);
            }
        }
    }
}



//        

