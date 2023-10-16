using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEstado : PlayerState {

    public IdleEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}

    public override void EntrarEstado() {
        base.EntrarEstado();
        //Debug.Log("idle entrando");
    }

    public override void SalirEstado() {
        base.SalirEstado();
        //Debug.Log("idle saliendo");
    }

    public override void ActualizarCuadro() {
        jugador.movimientoHorizontal = Input.GetAxisRaw("Horizontal") * jugador.velocidadMovimiento;
        jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
        if(jugador.movimientoHorizontal != 0){
            jugador.MaquinaEstado.cambiarEstado(jugador.movimientoEstado);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            jugador.salto = true;
            jugador.MaquinaEstado.cambiarEstado(jugador.saltoEstado);
        }
        if(Input.GetKeyDown(KeyCode.F) && jugador.hayEnfriamientoDash ) {
           jugador.puedeHacerDash = true;
           jugador.MaquinaEstado.cambiarEstado(jugador.dashEstado);
        }
        if( Input.GetKeyDown(KeyCode.E) ) {
            jugador.MaquinaEstado.cambiarEstado(jugador.ataqueEstado);
        }
        base.ActualizarCuadro();
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        
    }
}
