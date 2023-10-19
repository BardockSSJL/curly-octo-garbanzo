using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AtaqueEstado : PlayerState {
    public ContactFilter2D contacto;
    public Collider2D[] colliders;
    public BoxCollider2D hitBoxEspada;
    public LayerMask enemyLayer;
    public int hitCount;
    public int idDaño;
    private bool ataqueEnProceso = false;
    public AtaqueEstado(Jugador jugador, PlayerStateMachine maquinaEstado, LayerMask enemyLayerT, BoxCollider2D hitBoxEspadaT) : base(jugador, maquinaEstado) {
        enemyLayer = enemyLayerT;
        contacto = new ContactFilter2D();
        contacto.SetLayerMask(enemyLayer);
		colliders = new Collider2D[10];
        hitBoxEspada = hitBoxEspadaT;
        idDaño = 0;
    }
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

        var end = Time.time + 0.8f;
        // Mientras el tiempo de animación esté en proceso
        List<Enemy> hitEnemies = new List<Enemy>();
        while (Time.time < end) {
            // Obtenga los enemigos que están en el collider de la espada
		    hitCount = hitBoxEspada.OverlapCollider(contacto, colliders);
            for (int i = 0; i < hitCount; i++) {
                colliders[i].GetComponent<Enemy>().dannar(jugador.dañoAtaque);
                // Guarde a qué enemigo a golpeado
                hitEnemies.Add(colliders[i].GetComponent<Enemy>());
            }
            await Task.Yield();
        }

        jugador.animator.SetFloat("Horizontal", 0);
        ataqueEnProceso = false;
        // A todo enemigo que fue golpeado, permita que se le pueda volver a hacer dano
        foreach (Enemy bandido in hitEnemies) {
            bandido.fueGolpeado = false;
        }
        await Task.Delay(300);
    }
}
