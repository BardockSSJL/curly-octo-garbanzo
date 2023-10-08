using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEstado : PlayerState {
    public DashEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    private bool sePuedeMover = true;
    public override void EntrarEstado() {
        base.EntrarEstado();
        Debug.Log("dash entrando");
        
    }

    public override void SalirEstado() {
        base.SalirEstado();
        Debug.Log("dash saliendo");
        
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();

        if(jugador.movimientoHorizontal != 0){
            jugador.MaquinaEstado.cambiarEstado(jugador.movimientoEstado);
        }
        
    }

    public override void ActualizarFisica() {
        if(Input.GetKeyDown(KeyCode.F)) {
           Dash();
        }
        base.ActualizarFisica();
    }

    private IEnumerator Dash() {
        
        jugador.sePuedeMover = false;
        jugador.puedeHacerDash = false;
        jugador.RB.velocity = new Vector2(jugador.velocidadDash * jugador.transform.localScale.x, 0);
        jugador.animator.SetTrigger("Dash");
        jugador.trailRenderer.emitting = true;

        yield return new WaitForSeconds (jugador.tiempoDash);

        jugador.sePuedeMover = true;
        jugador.puedeHacerDash = true;
        jugador.RB.gravityScale = jugador.gravedadinicial;
        jugador.trailRenderer.emitting = false;

  }
}