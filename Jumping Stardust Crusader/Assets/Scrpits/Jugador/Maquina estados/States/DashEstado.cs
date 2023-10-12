using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        if(!jugador.puedeHacerDash && jugador.sePuedeMover){
            jugador.MaquinaEstado.cambiarEstado(jugador.idleEstado);
        }
    }

    public override void ActualizarFisica() {
        if(jugador.puedeHacerDash && jugador.sePuedeMover) {
            jugador.puedeHacerDash = false;
            Dash();
        }
        base.ActualizarFisica();
    }

    private async void Dash() {
        
        jugador.sePuedeMover = false;
        jugador.RB.velocity = new Vector2(jugador.velocidadDash * jugador.transform.localScale.x, 0);
        jugador.animator.SetTrigger("Dash");
        

        await Task.Delay((int)jugador.tiempoDash); 


        jugador.sePuedeMover = true;
        jugador.animator.SetTrigger("Dash");

  }
}