using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState estadoActual { get; set; }

    public void Inicializar(EnemyState estadoInicial) {
        estadoActual = estadoInicial;
        estadoActual.EntrarEstado();
    }

    public void cambiarEstado(EnemyState nuevoEstado) {
        estadoActual.SalirEstado();
        estadoActual = nuevoEstado;
        estadoActual.EntrarEstado();
    }
}
