using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEstado : PlayerState {
    private float suavizadoMovimiento = 0.3f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public MovimientoEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}

    public override void EntrarEstado() {
        base.EntrarEstado();
        //Debug.Log("movimiento entrando");
    }

    public override void SalirEstado() {
        base.SalirEstado();
        //Debug.Log("movimiento saliendo");
       
    }

    public override void ActualizarCuadro() {
        jugador.movimientoHorizontal = Input.GetAxisRaw("Horizontal") * jugador.velocidadMovimiento;
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(jugador.movimientoHorizontal));
        jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
        if(Input.GetKeyDown(KeyCode.W)){
            jugador.salto = true;
            jugador.MaquinaEstado.cambiarEstado(jugador.saltoEstado);
        }
        if(Input.GetKeyDown(KeyCode.F) && jugador.hayEnfriamientoDash) {
           jugador.puedeHacerDash = true;
           jugador.MaquinaEstado.cambiarEstado(jugador.dashEstado);
        }
        if( Input.GetKeyDown(KeyCode.E) ) {
            jugador.MaquinaEstado.cambiarEstado(jugador.ataqueEstado);
        }
        base.ActualizarCuadro();
    }

    public override void ActualizarFisica() {
        if(jugador.movimientoHorizontal != 0){
            Mover(jugador.movimientoHorizontal * Time.fixedDeltaTime);
        } else{
            jugador.MaquinaEstado.cambiarEstado(jugador.idleEstado);
        }
        base.ActualizarFisica();
    }

    private void Girar() {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = jugador.transform.localScale;
        escala.x *= -1;
        jugador.transform.localScale = escala;
    }

    private void Mover(float mover) {
        //Debug.Log("movimiendo");
        Vector3 velocidadObjetivo = new Vector2(mover,jugador.RB.velocity.y);
        jugador.RB.velocity = Vector3.SmoothDamp(jugador.RB.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }else if(mover < 0 && mirandoDerecha) {
            Girar();
        }
  }
}