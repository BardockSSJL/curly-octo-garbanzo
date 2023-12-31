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
        base.EntrarEstado();
    }

    public override void SalirEstado() {
        base.SalirEstado();
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        if (enemigo.vidaActual <= 0) enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoMuerto);
        else if (enemigo.EnRango) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoAtaque);
        }
        else if (!enemigo.EstadoAggro) {
            enemigo.MaquinaEstado.cambiarEstado(enemigo.EstadoEspera);
        }
        enemigo.animator.SetFloat("Velocidad", enemigo.RB.velocity.y);
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        if ((enemigo.jugador.transform.position.x < enemigo.transform.position.x && enemigo.viendoDerecha) ||
            enemigo.jugador.transform.position.x > enemigo.transform.position.x && !enemigo.viendoDerecha) {
            Girar();
        }
        
        Avanzar();
    }

    public void Avanzar() {
        RaycastHit2D informacionSuelo = enemigo.controladorSuelo.checkForSuelo();
        if (informacionSuelo) {
            enemigo.RB.velocity = new Vector2(enemigo.velocidadPersecucion, enemigo.RB.velocity.y);
        } else {
            enemigo.RB.velocity = new Vector2(0, enemigo.RB.velocity.y);
        }

    }

    private void Girar() {
        enemigo.viendoDerecha = !enemigo.viendoDerecha;
        enemigo.transform.eulerAngles = new Vector3(0, enemigo.transform.eulerAngles.y + 180, 0);
        enemigo.velocidadPersecucion *= -1;
    }

    
    
}
