using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AtaqueEstado : PlayerState {
    public AtaqueEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    private bool ataqueEnProceso = false;
    public override void EntrarEstado() {
        base.EntrarEstado();
        Debug.Log("ataque entrando");
    }

    public override void SalirEstado() {
        base.EntrarEstado();
        Debug.Log("ataque saliendo");
    }

    public override void ActualizarCuadro() {
        if( !Input.GetKey(KeyCode.E) && !ataqueEnProceso ) {
            jugador.MaquinaEstado.cambiarEstado(jugador.idleEstado);
        }
    }

    public override void ActualizarFisica() {
        if ( !ataqueEnProceso && jugador.enSuelo && Input.GetKey(KeyCode.E) ) {
            ataqueEnProceso = true;
            Attack();
        }
    }

    private async void Attack() {
        jugador.animator.SetTrigger("Ataque");

        await Task.Delay(520);

        jugador.animator.SetFloat("Horizontal", 0);
        jugador.animator.SetTrigger("Ataque");
        ataqueEnProceso = false;
    }
}
