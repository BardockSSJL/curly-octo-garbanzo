using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Jugador jugador;
    protected PlayerStateMachine maquinaEstadoJugador;

    public PlayerState(Jugador jugador, PlayerStateMachine maquinaEstado) {
        this.jugador = jugador;
        this.maquinaEstadoJugador = maquinaEstado;
    }

    public virtual void EntrarEstado() {}
    public virtual void SalirEstado(){}
    public virtual void ActualizarCuadro(){}
    public virtual void ActualizarFisica() {}

}