using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTicTacToeEjemplo : MonoBehaviour
{
    
    public TicTacToeTablero tablero;
    void Start()
    {
        tablero.Mover(0);
        tablero.Mover(1);
        tablero.Mover(4);
    }
}
