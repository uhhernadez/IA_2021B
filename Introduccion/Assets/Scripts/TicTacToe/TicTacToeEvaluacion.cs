using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeEvaluacion : MonoBehaviour
{ 
    public GameObject raiz; // root
    public TicTacToeTree arbol;
    public float costo_ganar = 5.0f;
    public float costo_perder = -5.0f;
    public float costo_empatar = 0;
    void Start()
    {
        EvaluarArbol();    
    }

    void EvaluarArbol() 
    {   
        string jugador = "X";
        string contrincante = "O";

        foreach (GameObject q in arbol.arbol) 
        { 
           if (q.GetComponent<TicTacToeTablero>().TresEnLinea(jugador)) 
           {
              //  Debug.Log("Configuración ganadora "); 
               GameObject padre = q.GetComponent<TicTacToeTablero>().padre;
               while (padre != null)
               { 
                   padre.GetComponent<TicTacToeTablero>().costo+=costo_ganar;
                   padre = padre.GetComponent<TicTacToeTablero>().padre;
               }
           }

           if (q.GetComponent<TicTacToeTablero>().Empate()) 
           { 
                GameObject padre = q.GetComponent<TicTacToeTablero>().padre;
                while (padre != null)
                { 
                    padre.GetComponent<TicTacToeTablero>().costo+=costo_empatar;
                    padre = padre.GetComponent<TicTacToeTablero>().padre;
                }
           
           }
           
           if (q.GetComponent<TicTacToeTablero>().TresEnLinea(contrincante)) 
           { 
                GameObject padre = q.GetComponent<TicTacToeTablero>().padre;
                while (padre != null)
                { 
                    padre.GetComponent<TicTacToeTablero>().costo+=costo_perder;
                    padre = padre.GetComponent<TicTacToeTablero>().padre;
                }
           }
        } 
    }

}
