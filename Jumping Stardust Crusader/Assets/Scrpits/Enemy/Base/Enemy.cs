using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMovable, ITriggerCheckable
{
	[field: SerializeField] public float vidaMaxima{ get; set; } = 100f;

	[field: SerializeField] public float vidaActual{ get; set; }

	[field: SerializeField] public float velocidadPersecucion{ get; set; }

	[field: SerializeField] public float velocidadAtaque{ get; set; }

	// ToDo: Volver privado
	internal Animator animator;
	
	
	public GameObject jugador {get; set; }

	public Rigidbody2D RB { get; set; }

    public bool viendoDerecha { get; set; } = true;
	public bool fueGolpeado { get; set; } = false;

	public bool EstadoAggro {get; set; }
    public bool EnRango { get; set; }

	#region controlador suelo
	[field: SerializeField] public controladorSueloEnemigo controladorSuelo { get; set; }
	[field: SerializeField] public ControladorAtaqueEnemigo controladorAtaque { get; set; }

	#endregion

	#region VariablesMaquinaEstado
	public EnemyStateMachine MaquinaEstado { get; set; }
	public EnemyIdleState EstadoEspera { get; set; }
	public EnemyChaseState EstadoPersecucion { get; set; }
	public EnemyAttackState EstadoAtaque {	get; set; }
	#endregion


	private void Awake() {
		MaquinaEstado = new EnemyStateMachine();
		EstadoEspera = new EnemyIdleState(this, MaquinaEstado);
		EstadoPersecucion = new EnemyChaseState(this, MaquinaEstado);
		EstadoAtaque = new EnemyAttackState(this, MaquinaEstado);
		jugador = GameObject.FindGameObjectWithTag("Jugador");
		animator = GetComponent<Animator>();
		if (velocidadAtaque == 0) velocidadAtaque = 2;
	}
	
	private void Start() {
		vidaActual = vidaMaxima;
		RB = GetComponent<Rigidbody2D>();
		MaquinaEstado.Inicializar(EstadoEspera);
	}


	private void FixedUpdate() {
		MaquinaEstado.estadoActual.ActualizarFisica();
		
	}

	private void Update() {
		MaquinaEstado.estadoActual.ActualizarCuadro();
	}

	#region movimiento
	public void moverEnemigo (Vector2 velocidad) {
		RB.velocity = velocidad;
		revisarDireccion(velocidad);
	}

    public void revisarDireccion(Vector2 velocidad) {}
	#endregion

	#region danno/muerte
	public void dannar(float cantidadDanno) {
		if (!fueGolpeado) {
			vidaActual -= cantidadDanno;
			Debug.Log("Recibi dano");
			fueGolpeado = true;
		}
		if (vidaActual <= 0) {
			morir();
		}
	}

    public void morir() {
		Destroy(gameObject);
	}
	#endregion

	#region CheckDistancia
	public void SetEstadoAggro (bool TieneAggro) {
		EstadoAggro = TieneAggro;
	}

	public void SetEnRango (bool EstaEnRango) {
		EnRango = EstaEnRango;
	}
	#endregion

	#region animaitonTriggers
	public void EventoTriggerAnim(Enemy.TipoTriggerAnimacion tipo) {
		MaquinaEstado.estadoActual.EventoTriggerAnim(tipo);
	}

	public enum TipoTriggerAnimacion {
		EnemigoDannado,
		EnemigoMuere
	}
	#endregion

	// ignorar este comentario

	
}
