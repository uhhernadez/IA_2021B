using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreHanoiAgente : MonoBehaviour
{
    public TorreHanoiEntorno entorno;


    float ultimoMov;
    int ultimaPieza = -1;
    void Update()
    { /*
        if(Time.realtimeSinceStartup - ultimoMov > 0.3f) 
        {
            int origen;
            int destino;
 
            do 
            {
                origen = UnityEngine.Random.Range(0,3);
                destino = UnityEngine.Random.Range(0,3);
            } while (origen == destino);

            if (ultimaPieza != entorno.PiezaTorre(origen)) {
                ultimaPieza = entorno.MoverPiezaTorre(origen, destino);
            }

            //int torre0 = entorno.PiezaTorre(0);
            //int torre1 = entorno.PiezaTorre(1);
            //int torre2 = entorno.PiezaTorre(2);
            ultimoMov = Time.realtimeSinceStartup;
        }
        */
//        Debug.Log(Time.realtimeSinceStartup);


        if(Time.realtimeSinceStartup - ultimoMov > 0.3f) 
        {
            int origen;
            int destino;
 
            int torre0 = entorno.PiezaTorre(0);
            int torre1 = entorno.PiezaTorre(1);
            int torre2 = entorno.PiezaTorre(2);
        }

    }
}
