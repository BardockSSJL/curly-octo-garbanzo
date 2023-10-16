using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{  
    [field: SerializeField] public float vidaMaxima{ get; set; } = 100f;

	[field: SerializeField] public float vidaActual{ get; set; }

	[field: SerializeField] public LayerMask queEsSuelo{ get; set; }

	[field:SerializeField] public Transform controlSuelo{ get; set; }

	[field:SerializeField] public Vector3 dimensionesCaja{ get; set; }

	[field:SerializeField] public float velocidadDash{ get; set; }

    [field:SerializeField] public float tiempoDash{ get; set; }

    [field:SerializeField] public TrailRenderer trailRenderer{ get; set; }

	[field:SerializeField] public float gravedadinicial { get; set; }
	public bool puedeHacerDash = false;

    [SerializeField] public bool enSuelo{ get; set; }

	public float movimientoHorizontal = 0f;

	public float velocidadMovimiento = 400;

	public Rigidbody2D RB { get; set; }

    public bool viendoDerecha { get; set; }

	public bool sePuedeMover { get; set; } = true;

    public PlayerStateMachine MaquinaEstado { get; set; }

    public MovimientoEstado movimientoEstado {get; set; }

	public SaltoEstado saltoEstado {get; set; }

	public IdleEstado idleEstado {get; set; }
	public DashEstado dashEstado {get; set; }

	#region  dano
	public AtaqueEstado ataqueEstado {get; set; }
	public LayerMask enemyLayer;
	public BoxCollider2D hitBoxEspada;
	[field: SerializeField] public float dañoAtaque{ get; set; } = 25f;
	#endregion

	public float fuerzaSalto = 400f;

    public bool salto = false;

	public Animator animator;

    private void Awake() {
		MaquinaEstado = new PlayerStateMachine();
		movimientoEstado = new MovimientoEstado(this, MaquinaEstado);
		saltoEstado = new SaltoEstado(this, MaquinaEstado);
		idleEstado = new IdleEstado(this, MaquinaEstado);
		dashEstado = new DashEstado(this, MaquinaEstado);
		hitBoxEspada = GameObject.Find("hitBoxEspada").GetComponent<BoxCollider2D>();
		ataqueEstado = new AtaqueEstado(this, MaquinaEstado, enemyLayer, hitBoxEspada);
		animator = GetComponent<Animator>();
		
	}

    private void Start() {
		vidaActual = vidaMaxima;
		RB = GetComponent<Rigidbody2D>();
		MaquinaEstado.Inicializar(movimientoEstado);
		animator = GetComponent<Animator>();
	}


	private void FixedUpdate() {
		MaquinaEstado.estadoActual.ActualizarFisica();
		
	}

	private void Update() {
		MaquinaEstado.estadoActual.ActualizarCuadro();
	}
	
}
