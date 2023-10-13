using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){}

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        base.EntrarEstado();
        enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
        Debug.Log("FUS RO DAH!");
    }

    public override void SalirEstado() {
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
    }
}
