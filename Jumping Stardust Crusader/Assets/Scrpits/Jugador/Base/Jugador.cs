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
	
	#region dash
	[field:SerializeField] public float velocidadDash{ get; set; }

    [field:SerializeField] public float tiempoDash{ get; set; }

	[field:SerializeField] public int enfriamientoDash{ get; set; }
	
	public bool puedeHacerDash = false;

	public bool hayEnfriamientoDash = true;
	#endregion

    [field:SerializeField] public TrailRenderer trailRenderer{ get; set; }

	[field:SerializeField] public float gravedadinicial { get; set; }

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

	public void RecibirDanno(float cantidad){
		vidaActual -= cantidad;
	}

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

	private void tomarPocion(int tipo){
		switch (tipo)
		{
			case 1:
			if(GetComponent<InventarioJugador>().PocionVidaDisponible) {
				Debug.Log("Pocion usada");
				GetComponent<InventarioJugador>().PocionVidaDisponible = false;
			} else {
				Debug.Log("Pocion no disponible");
			}
			break;
			case 2:
			if(GetComponent<InventarioJugador>().PocionVidaDisponible) {
				Debug.Log("Pocion daño usada");
				GetComponent<InventarioJugador>().PocionVidaDisponible = false;
			} else {
				Debug.Log("Pocion no disponible");
			}
			break;
			case 3:
			if(GetComponent<InventarioJugador>().PocionVidaDisponible) {
				Debug.Log("Pocion armadura usada");
				GetComponent<InventarioJugador>().PocionVidaDisponible = false;
			} else {
				Debug.Log("Pocion no disponible");
			}
			break;
			default:
			break;
		}
	}

	public void agregarPocion(int tipo){
				switch (tipo)
		{
			case 1:
			GetComponent<InventarioJugador>().PocionVidaDisponible = true;
			break;
			case 2:
			GetComponent<InventarioJugador>().PocionDannoDisponible = true;
			break;
			case 3:
			GetComponent<InventarioJugador>().PocionArmaduraDisponible = true;
			break;
			default:
			break;
		}
	}

	private void Update() {
		MaquinaEstado.estadoActual.ActualizarCuadro();
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			tomarPocion(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			tomarPocion(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			tomarPocion(3);
		}
	}
	


	#region Dibujo de gizmos
	private void OnDrawGizmos() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireCube(controlSuelo.position, dimensionesCaja);
    }
	#endregion
}
