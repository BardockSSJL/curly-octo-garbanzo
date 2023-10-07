using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){}

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        Debug.Log("Entrar estado: Persecucion");
        base.EntrarEstado();
    }

    public override void SalirEstado() {
        Debug.Log("Salir estado: Persecucion");
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();

        if (!enemigo.EstadoAggro) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoEspera);
        }
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
    }
}
