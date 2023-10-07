using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaMovimiento : MonoBehaviour
{
  private Rigidbody2D rb2D;

  [Header("Movimiento")]
  private float movimientoHorizontal = 0f;
  [SerializeField]private float velocidadMovimiento;
  [Range(0, 0.3f)][SerializeField]private float suavizadoMovimiento;
  private Vector3 velocidad = Vector3.zero;
  private bool mirandoDerecha = true;

  [Header("Salto")]
  [SerializeField] private float fuerzaSalto;
  [SerializeField] private LayerMask queEsSuelo;
  [SerializeField] private Transform controlSuelo;
  [SerializeField] private Vector3 dimensionesCaja;
  [SerializeField] private bool enSuelo;
  private bool salto = false;

  [Header("Dash")]
  [SerializeField] private float velocidadDash;
  [SerializeField] private float tiempoDash;
  [SerializeField] private TrailRenderer trailRenderer;
  private float gravedadinicial;
  private bool puedeHacerDash = true;
  private bool sePuedeMover = true;

  [Header("Animacion")]
  private Animator animator;

  private void Start() {
    rb2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    gravedadinicial = rb2D.gravityScale;
  }

  private void Update() {
    movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
    animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
    if(Input.GetButtonDown("Jump")){
      salto = true;
    }
    if(Input.GetKeyDown(KeyCode.B) && puedeHacerDash) {
      StartCoroutine(Dash());
    }
  }

  private void FixedUpdate() {
      enSuelo = Physics2D.OverlapBox(controlSuelo.position, dimensionesCaja, 0f, queEsSuelo);
      animator.SetBool("enSuelo",enSuelo);
      //movimiento de la vara
      if(sePuedeMover) {
          Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
      }

      salto = false;
  }

  private void Mover(float mover, bool saltar) {
      Vector3 velocidadObjetivo = new Vector2(mover,rb2D.velocity.y);
      rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);

      if (mover > 0 && !mirandoDerecha) {
          Girar();
      }else if(mover < 0 && mirandoDerecha) {
          Girar();
      }
      if(enSuelo && saltar) {
          enSuelo = false;
          rb2D.AddForce(new Vector2(0f, fuerzaSalto));
      }
  }

  private void Girar() {
      mirandoDerecha = !mirandoDerecha;
      Vector3 escala = transform.localScale;
      escala.x *= -1;
      transform.localScale = escala;
  }

  private void OnDrawGizmos() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireCube(controlSuelo.position, dimensionesCaja);
  }

  private IEnumerator Dash() {
      sePuedeMover = false;
      puedeHacerDash = false;
      rb2D.velocity = new Vector2(velocidadDash * transform.localScale.x, 0);
      animator.SetTrigger("Dash");
      trailRenderer.emitting = true;

      yield return new WaitForSeconds (tiempoDash);

      sePuedeMover = true;
      puedeHacerDash = true;
      rb2D.gravityScale = gravedadinicial;
      trailRenderer.emitting = false;

  }
}