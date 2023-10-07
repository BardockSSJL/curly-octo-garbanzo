using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState estadoActual { get; set; }

    public void Inicializar(PlayerState estadoInicial) {
        estadoActual = estadoInicial;
        estadoActual.EntrarEstado();
    }

    public void cambiarEstado(PlayerState nuevoEstado) {
        estadoActual.SalirEstado();
        estadoActual = nuevoEstado;
        estadoActual.EntrarEstado();
    }
}