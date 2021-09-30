using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreHanoiAgente : MonoBehaviour
{
    public TorreHanoiEntorno entorno;


    float ultimoMov;
    void Update()
    {
        if(Time.realtimeSinceStartup - ultimoMov > 0.3f) 
        {
            /*
            int t = Random.Range(0,3);
            int p = Random.Range(0,7);
            piezas[p].transform.localPosition = torres[t];
            */
            
            int origen = UnityEngine.Random.Range(0,3);
            int destino = UnityEngine.Random.Range(0,3);
            entorno.MoverPiezaTorre(origen, destino);
            ultimoMov = Time.realtimeSinceStartup;
        }
        Debug.Log(Time.realtimeSinceStartup);
        
    }
}
