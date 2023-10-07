using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemigo;
    protected EnemyStateMachine maquinaEstadoEnemiga;

    public EnemyState(Enemy enemigo, EnemyStateMachine maquinaEstado) {
        this.enemigo = enemigo;
        this.maquinaEstadoEnemiga = maquinaEstado;
    }

    public virtual void EntrarEstado() {}
    public virtual void SalirEstado(){}
    public virtual void ActualizarCuadro(){}
    public virtual void ActualizarFisica() {}
    public virtual void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipo) {}
}
