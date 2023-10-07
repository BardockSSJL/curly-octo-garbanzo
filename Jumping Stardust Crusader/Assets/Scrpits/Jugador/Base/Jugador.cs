using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{  
    [field: SerializeField] public float vidaMaxima{ get; set; } = 100f;

	[field: SerializeField] public float vidaActual{ get; set; }

	[field: SerializeField] public LayerMask queEsSuelo;
	[SerializeField] public Transform controlSuelo;
	[SerializeField] public Vector3 dimensionesCaja;
    [SerializeField] public bool enSuelo;

	public Rigidbody2D RB { get; set; }

    public bool viendoDerecha { get; set; }

	public bool SePuedeMover { get; set; } = true;

    public PlayerStateMachine MaquinaEstado { get; set; }
    public MovimientoEstado movimientoEstado {get; set; }

	public Animator animator;

    private void Awake() {
		MaquinaEstado = new PlayerStateMachine();
		movimientoEstado = new MovimientoEstado(this, MaquinaEstado);
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
