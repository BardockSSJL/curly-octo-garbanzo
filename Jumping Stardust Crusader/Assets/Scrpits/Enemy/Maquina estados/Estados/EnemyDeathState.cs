using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

// este script está interpretando los literales decimales cmo double
public class EnemyDeathState : EnemyState
{
    private bool caer;
    private DateTime tiempoMuerte, tiempoActual;

    public EnemyDeathState(Enemy enemigo, EnemyStateMachine maquina) : base(enemigo, maquina){
        caer = true;
    }

    public override void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipoTrigger) {
        base.EventoTriggerAnim(tipoTrigger);
    }

    public override void EntrarEstado() {
        enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
        enemigo.animator.SetTrigger("Morir");
        tiempoMuerte = DateTime.Now;
        //enemigo.RB.simulated = false;
        enemigo.GetComponent<Collider2D>().enabled = false;
        for (int i = 0; i < enemigo.transform.childCount; ++i) {
            enemigo.transform.GetChild(i).gameObject.SetActive(false);
        }
        base.EntrarEstado();
    }

    public override void SalirEstado() {
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        tiempoActual = DateTime.Now;
        if ((double)((TimeSpan)(tiempoActual - tiempoMuerte)).TotalMilliseconds > 5000) {
            enemigo.morir();
        }
        
        // Moví lo de la caída al Update y dejó de atravesar el suelo
        
        base.ActualizarCuadro();
    }

    public override void ActualizarFisica() {
        // si el enemigo muere en el aire cae hasta tocar el suelo y se detiene
        // si cae desde muy alto podría atravesar el collider del suelo y no dejar de caer

        if (caer) {
            if (Physics2D.OverlapBox(enemigo.transform.position + enemigo.controladorSuelo.posicionCaja, enemigo.controladorSuelo.posicionCaja, 0f, 1 << LayerMask.NameToLayer("Piso"))) {
                enemigo.RB.simulated = false;
                caer = false;
            }
        }
        
        base.ActualizarFisica();
    }

}