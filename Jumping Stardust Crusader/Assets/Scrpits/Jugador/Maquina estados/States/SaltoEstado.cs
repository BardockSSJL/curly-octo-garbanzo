using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoEstado : PlayerState {
    public SaltoEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    public override void EntrarEstado() {
        base.EntrarEstado();
        Debug.Log("Salto entrando"); 
        //jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        //jugador.animator.SetBool("enSuelo",jugador.enSuelo);
    }

    public override void SalirEstado() {
        base.SalirEstado();
        Debug.Log("Salto saliendo");
        //jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        //jugador.animator.SetBool("enSuelo",jugador.enSuelo);
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        if(Input.GetKeyDown(KeyCode.W)){
            
            jugador.salto = true;
        }
        
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
        Salto(jugador.salto);
         if(jugador.movimientoHorizontal != 0){
            jugador.MaquinaEstado.cambiarEstado(jugador.movimientoEstado);
        }
        if(jugador.movimientoHorizontal == 0){
            jugador.MaquinaEstado.cambiarEstado(jugador.idleEstado);
        }
    }

    private void Salto (bool saltar) {
        Debug.Log(jugador.enSuelo);
        Debug.Log(saltar);

        if(jugador.enSuelo && saltar) {
            jugador.enSuelo = false;
            jugador.RB.AddForce(new Vector2(0f, jugador.fuerzaSalto));
        }
    }

    private void OnDrawGizmos() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireCube(jugador.controlSuelo.position, jugador.dimensionesCaja);
  }
}