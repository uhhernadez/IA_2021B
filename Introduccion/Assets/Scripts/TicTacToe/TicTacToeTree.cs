using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeTree : MonoBehaviour
{
//    public GameObject node;
    public GameObject raiz; // root
    public List<GameObject> arbol = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
       if(raiz != null) 
       { 
            raiz.name = "Tablero0";
            arbol.Add(raiz);
            CrearArbol(ref raiz, 6);
            OrganizarArbol();
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearArbol(ref GameObject nodo, int profundidad) 
    { 
        TicTacToeTablero tablero = nodo.GetComponent<TicTacToeTablero>();

        if (tablero.TerminoJuego()) 
        { 
            return;
        }

        if (tablero.turno == profundidad) 
        { 
            return;
        }

        List<int> movimientos = tablero.Movimientos();

        foreach(int movimiento in movimientos) 
        {
            Vector3 hijo_pos = new Vector3(nodo.transform.position.x + 0.8f, 0, 0);
            GameObject hijo = Instantiate<GameObject>(nodo, hijo_pos, Quaternion.identity);
            TicTacToeTablero tablero_hijo = hijo.GetComponent<TicTacToeTablero>();
            tablero_hijo.hijos = new List<GameObject>();
            tablero_hijo.Mover(movimiento);
            CrearArbol(ref hijo, profundidad);
            tablero.hijos.Add(hijo); 
            tablero_hijo.padre = nodo;
            hijo.name = nodo.name + tablero_hijo.turno;
            arbol.Add(hijo);
            // Recursión
        }

    }

    void OrganizarArbol() 
    { 
        int profundidad = 0;

        foreach(GameObject nodo in arbol) 
        { 
            TicTacToeTablero t = nodo.GetComponent<TicTacToeTablero>();
            if (t.turno > profundidad) 
            { 
                profundidad = t.turno;
            }
        }
        
        profundidad++;

        List<GameObject> [] objetos = new List<GameObject>[profundidad];
        
        for (int k = 0; k < profundidad; k++)
        { 
            objetos[k] = new List<GameObject>();
        }

        foreach(GameObject nodo in arbol) 
        { 
            TicTacToeTablero t = nodo.GetComponent<TicTacToeTablero>();
            objetos[t.turno].Add(nodo);
        }
        
        for (int k = 1; k < profundidad; k++)
        { 
            Debug.Log("Nivel : " + k + " nodos " + objetos[k].Count); 
            for (int i = 1; i < objetos[k].Count; i++) 
            {
                objetos[k][i].transform.position = objetos[k][i-1].transform.position + 0.8f * Vector3.forward; 
            }
        }
        arbol[0].transform.position = Vector3.zero;
    }

}
