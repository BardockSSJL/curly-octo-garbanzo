using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEstado : PlayerState {

    public IdleEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}

    public override void EntrarEstado() {
        base.EntrarEstado();
        jugador.animator.SetBool("Idle", true);
    }

    public override void SalirEstado() {
        base.SalirEstado();
        jugador.animator.SetBool("Idle", false);
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        
    }
}
