using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejecucion : MonoBehaviour
{
    public Agente agente;
    public Configuracion configuracion;

    public int index = 0;

    float lastTime;
    public float deltaT = 0.5f;
    void Start() {
        lastTime = Time.realtimeSinceStartup;
    }
    
    void Update() {
        agente.goal = configuracion.posiciones[index];

            if (agente.enMeta) 
            {
                if (Time.realtimeSinceStartup - lastTime > deltaT) 
                {
                    index++;
                    if( index >= configuracion.posiciones.Length) 
                    {
                        index = configuracion.posiciones.Length-1;
                    }
                    lastTime = Time.realtimeSinceStartup;
                }

            }
    }
            
}

    


