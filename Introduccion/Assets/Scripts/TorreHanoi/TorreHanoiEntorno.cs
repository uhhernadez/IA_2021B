using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TorreHanoiEntorno : MonoBehaviour
{
    public GameObject [] piezas;
    public Vector3 [] torres;

    private Stack<GameObject>  [] torre_piezas = new Stack<GameObject>[3];
    float ultimoMov;
    void Start() 
    {
        if ( piezas == null)
            Debug.LogError("No hay piezas asignadas");

        torre_piezas[0] = new Stack<GameObject>();
        torre_piezas[0].Push(piezas[6]);
        torre_piezas[0].Push(piezas[5]);
        torre_piezas[0].Push(piezas[4]);
        torre_piezas[0].Push(piezas[3]);
        torre_piezas[0].Push(piezas[2]);
        torre_piezas[0].Push(piezas[1]);
        torre_piezas[0].Push(piezas[0]);

        torre_piezas[1] = new Stack<GameObject>();
        torre_piezas[2] = new Stack<GameObject>();

        Debug.Log(piezas.Length);
        ultimoMov = Time.realtimeSinceStartup;
    }

    void Update() 
    {
    }

    public void MoverPiezaTorre(int origen, int destino) 
    {
        if (origen >=0 && origen <3) 
        {
            if( destino >=0 && destino <3)
            {
                if (torre_piezas[origen].Count == 0) 
                {
                    Debug.LogWarning("La torre de origen no tiene piezas");
                    return;
                }
                int origen_t = Convert.ToInt32(torre_piezas[origen].Peek().name);
                int destino_t = (torre_piezas[destino].Count ==0 )? 100 : Convert.ToInt32(torre_piezas[destino].Peek().name);
                
                if(origen_t > destino_t) 
                {
                    Debug.LogWarning("Movimiento inválido");
                    return;
                }

                GameObject g = torre_piezas[origen].Pop();
                torre_piezas[destino].Push(g);
                g.transform.localPosition = torres[destino];
            }
        }

    }
}
