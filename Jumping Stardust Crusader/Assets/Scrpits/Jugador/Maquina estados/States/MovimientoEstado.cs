using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEstado : PlayerState {

    private float movimientoHorizontal = 0f;
     private float velocidadMovimiento = 400;
     private float suavizadoMovimiento = 0.3f;
     private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public MovimientoEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}

    public override void EntrarEstado() {
        base.EntrarEstado();
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
    }

    public override void SalirEstado() {
        base.SalirEstado();
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
       
    }

    public override void ActualizarCuadro() {
        base.ActualizarFisica();
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
    }

    private void Girar() {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = jugador.transform.localScale;
        escala.x *= -1;
        jugador.transform.localScale = escala;
    }

    private void Mover(float mover) {
        Vector3 velocidadObjetivo = new Vector2(mover,jugador.RB.velocity.y);
        jugador.RB.velocity = Vector3.SmoothDamp(jugador.RB.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }else if(mover < 0 && mirandoDerecha) {
            Girar();
        }
  }
}