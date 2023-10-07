using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEstado : PlayerState {

    private float movimientoHorizontal = 0f;
    private float velocidadMovimiento = 400;
    private float suavizadoMovimiento = 0.3f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private float fuerzaSalto = 400f;
     private bool salto = false;
    public MovimientoEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}

    public override void EntrarEstado() {
        base.EntrarEstado();
        Debug.Log("movimiento entrando");
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
    }

    public override void SalirEstado() {
        base.SalirEstado();
        Debug.Log("movimiento saliendo");
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(0));
       
    }

    public override void ActualizarCuadro() {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        jugador.animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
        if(Input.GetKeyDown(KeyCode.W)){
            salto = true;
        }
        base.ActualizarFisica();
    }

    public override void ActualizarFisica() {
        jugador.enSuelo = Physics2D.OverlapBox(jugador.controlSuelo.position, jugador.dimensionesCaja, 0f, jugador.queEsSuelo);
        jugador.animator.SetBool("enSuelo",jugador.enSuelo);
        if(salto == true || movimientoHorizontal != 0){
            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        }
        

        salto = false;
    }

    private void Girar() {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = jugador.transform.localScale;
        escala.x *= -1;
        jugador.transform.localScale = escala;
    }

    private void Mover(float mover, bool saltar) {
        Debug.Log("movimiendo");
        Vector3 velocidadObjetivo = new Vector2(mover,jugador.RB.velocity.y);
        jugador.RB.velocity = Vector3.SmoothDamp(jugador.RB.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }else if(mover < 0 && mirandoDerecha) {
            Girar();
        }
        if(jugador.enSuelo && saltar) {
          jugador.enSuelo = false;
          jugador.RB.AddForce(new Vector2(0f, fuerzaSalto));
      }
  }
}