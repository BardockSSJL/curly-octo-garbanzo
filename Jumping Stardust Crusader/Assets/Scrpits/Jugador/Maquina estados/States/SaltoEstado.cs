using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoEstado : PlayerState {
    public SaltoEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    private float fuerzaSalto = 400f;
     private bool salto = false;
    public override void EntrarEstado() {
        base.EntrarEstado();
        jugador.animator.SetBool("enSuelo",jugador.enSuelo); 
    }

    public override void SalirEstado() {
        base.SalirEstado();
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
        if(Input.GetKeyDown(KeyCode.B)){
            salto = true;
            Salto(salto);
            salto = false;
        }
    }

    private void Salto (bool saltar) {
        if(jugador.enSuelo && saltar) {
          jugador.enSuelo = false;
          jugador.RB.AddForce(new Vector2(0f, fuerzaSalto));
      }
    }

    private void OnDrawGizmos() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireCube(jugador.controlSuelo.position, jugador.dimensionesCaja);
  }
}