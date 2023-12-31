using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class EnemyAttackState : EnemyState
{
    private DateTime tiempoUltimoAtaque, tiempoActual;

    public EnemyAttackState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){
        tiempoUltimoAtaque = DateTime.Now.AddMilliseconds((double)(-(enemigo.velocidadAtaque * 1000)));
    }

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        base.EntrarEstado();
        enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
    }

    public override void SalirEstado() {
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        // cambio de estado
        if (enemigo.vidaActual <= 0) enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoMuerto);
        else if (enemigo.EstadoAggro && !(enemigo.EnRango)) {
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
        if ((enemigo.jugador.transform.position.x < enemigo.transform.position.x && enemigo.viendoDerecha) ||
            enemigo.jugador.transform.position.x > enemigo.transform.position.x && !enemigo.viendoDerecha) {
            Girar();
        }
    }

    public void Atacar() {
        //Debug.Log("FUS RO DAH!");
        enemigo.animator.SetTrigger("Atacar");
        tiempoUltimoAtaque = DateTime.Now;
    }

    private void Girar() {
        enemigo.viendoDerecha = !enemigo.viendoDerecha;
        enemigo.transform.eulerAngles = new Vector3(0, enemigo.transform.eulerAngles.y + 180, 0);
        enemigo.velocidadPersecucion *= -1;
    }
}


// adaptado de https://stackoverflow.com/questions/13589853/time-elapse-computation-in-milliseconds-c-sharp
//DateTime startTime, endTime;
//startTime = DateTime.Now;

//do your work

//endTime = DateTime.Now;
//Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;