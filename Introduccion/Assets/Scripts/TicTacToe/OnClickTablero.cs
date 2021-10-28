using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickTablero : MonoBehaviour,  IPointerClickHandler
{
    public TicTacToeTablero tablero;
    public int posicion;
    public void OnPointerClick(PointerEventData pointerEventData) {
        Debug.Log("Collision");
        tablero.Mover(posicion); 
    }
}
