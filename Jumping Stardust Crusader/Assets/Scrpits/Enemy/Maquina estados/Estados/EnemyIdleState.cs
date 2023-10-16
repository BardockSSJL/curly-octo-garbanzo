using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){}

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
        //Debug.Log("Entrar estado: Espera");
        base.EntrarEstado();
    }

    public override void SalirEstado() {
        //Debug.Log("Salir estado: Espera");
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        if (enemigo.EstadoAggro) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoPersecucion);
        }
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
    }

}
