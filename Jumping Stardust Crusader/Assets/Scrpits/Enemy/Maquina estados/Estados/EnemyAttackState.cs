using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class EnemyAttackState : EnemyState
{
    private DateTime tiempoUltimoAtaque, tiempoActual;

    public EnemyAttackState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){}

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        base.EntrarEstado();
        enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
        tiempoUltimoAtaque = DateTime.Now.AddMilliseconds((double)(-(enemigo.velocidadAtaque * 1000)));
    }

    public override void SalirEstado() {
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        // cambio de estado
        if (enemigo.EstadoAggro && !(enemigo.EnRango)) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoPersecucion);
        }
        else if (!(enemigo.EstadoAggro) && !(enemigo.EnRango)) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoEspera);
        }

        tiempoActual = DateTime.Now;
        double tiempoTranscurrido = (double)((TimeSpan)(tiempoActual - tiempoUltimoAtaque)).TotalMilliseconds;
        if (tiempoTranscurrido > (enemigo.velocidadAtaque) * 1000) Atacar();
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
    }

    public void Atacar() {
        Debug.Log("FUS RO DAH!");
        tiempoUltimoAtaque = DateTime.Now;
    }
}


// adaptado de https://stackoverflow.com/questions/13589853/time-elapse-computation-in-milliseconds-c-sharp
//DateTime startTime, endTime;
//startTime = DateTime.Now;

//do your work

//endTime = DateTime.Now;
//Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;