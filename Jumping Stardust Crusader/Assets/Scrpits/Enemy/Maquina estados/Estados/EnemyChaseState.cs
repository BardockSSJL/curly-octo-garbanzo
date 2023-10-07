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
        if ((enemigo.jugador.transform.position.x < enemigo.transform.position.x && enemigo.viendoDerecha) ||
            enemigo.jugador.transform.position.x > enemigo.transform.position.x && !enemigo.viendoDerecha) {
            Girar();
        }
        
        Avanzar();
    }

    public void Avanzar() {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(enemigo.controladorSuelo.position, Vector2.down, enemigo.distanciaAlSuelo, 1 << LayerMask.NameToLayer("Piso"));
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

    
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(enemigo.controladorSuelo.transform.position, enemigo.controladorSuelo.transform.position + Vector3.down * enemigo.distanciaAlSuelo);
    }
    
    
}
