using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEstado : PlayerState {
    public DashEstado(Jugador jugador, PlayerStateMachine maquinaEstado) : base(jugador, maquinaEstado) {}
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempoDash;
    [SerializeField] private TrailRenderer trailRenderer;
    private float gravedadinicial;
    private bool puedeHacerDash = true;
    private bool sePuedeMover = true;
    public override void EntrarEstado() {
        base.EntrarEstado();
        
    }

    public override void SalirEstado() {
        base.SalirEstado();
        
    }

    public override void ActualizarCuadro() {
        base.ActualizarCuadro();
        if(Input.GetKeyDown(KeyCode.B) && puedeHacerDash) {
           Dash();
        }
        
    }

    public override void ActualizarFisica() {
        base.ActualizarFisica();
    }

    private IEnumerator Dash() {
      sePuedeMover = false;
      puedeHacerDash = false;
      jugador.RB.velocity = new Vector2(velocidadDash * jugador.transform.localScale.x, 0);
      jugador.animator.SetTrigger("Dash");
      trailRenderer.emitting = true;

      yield return new WaitForSeconds (tiempoDash);

      sePuedeMover = true;
      puedeHacerDash = true;
      jugador.RB.gravityScale = gravedadinicial;
      trailRenderer.emitting = false;

  }
}