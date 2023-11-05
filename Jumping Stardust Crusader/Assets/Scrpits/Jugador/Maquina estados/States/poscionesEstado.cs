using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoscionesEstado : PlayerState {
    public PoscionesEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    public override void EntrarEstado() {
        base.EntrarEstado();
    }

    public override void SalirEstado() {
        base.EntrarEstado();
    }

    public override void ActualizarCuadro() {
    }

    public override void ActualizarFisica() {
    }

}
