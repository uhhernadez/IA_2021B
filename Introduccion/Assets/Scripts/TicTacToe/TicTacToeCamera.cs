using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeCamera : MonoBehaviour
{
    public GameObject camera;
    public TicTacToeTree arbol;
    public Vector3 meta;
    public int posicion = 0; 
    public List<Vector3> posiciones = new List<Vector3>();
    public float ultima_ejecucion;
    public float tiempo_desplazamiento = 3;
    void Start()
    {
        camera.transform.position = arbol.arbol[0].transform.position + Vector3.up*0.5f;
        BusquedaProfundidad();
        StartCoroutine(SecuenciadorPosicion());
    }

    private void FixedUpdate()
    {
        float t = (Time.realtimeSinceStartup - ultima_ejecucion)/tiempo_desplazamiento;
//        Debug.Log(t);
//        float x = Mathf.Lerp(camera.transform.position.x, meta.x, (Time.realtimeSinceStartup - ultima_ejecucion)/tiempo_desplazamiento); 
//        float z = Mathf.Lerp(camera.transform.position.z, meta.z, (Time.realtimeSinceStartup - ultima_ejecucion)/tiempo_desplazamiento); 
//        camera.transform.position = new Vector3(x, meta.y, z);
        camera.transform.position = Vector3.Lerp(camera.transform.position, meta, t);
    }

    IEnumerator SecuenciadorPosicion() 
    { 
        while (posicion < posiciones.Count ) 
        { 
            meta = posiciones[posicion] + 0.8f * Vector3.up;
            posicion++;
            ultima_ejecucion = Time.realtimeSinceStartup;
            //yield return new WaitForSeconds(tiempo_desplazamiento);
            yield return new WaitForSecondsRealtime(tiempo_desplazamiento);
        }
    }
    void BusquedaProfundidad() 
    { 
        Stack<GameObject> pila = new Stack<GameObject>();
        pila.Push(arbol.arbol[0]);

        while(pila.Count != 0) 
        { 
            GameObject pop = pila.Pop();
            posiciones.Add(pop.transform.position);
            for (int k = 0; k < pop.GetComponent<TicTacToeTablero>().hijos.Count; k++ ) 
            { 
                pila.Push(pop.GetComponent<TicTacToeTablero>().hijos[k]);
            }
        }
    }


}
