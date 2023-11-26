using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pociones;
using System;

public class Dispensador : MonoBehaviour, IInteractuable {

    public bool Activo { get; set; }
    public bool EnRango { get; set; }
    public GameObject Jugador { get; set; }
    public GameObject Indicador { get; set; }
    //fabrica 
    [SerializeField] private ListaPociones Config;
    private FabricaAbstracta fabrica;

    [SerializeField] private String TipoDePocion;
    
    void Start()
    {
        fabrica = new FabricaAbstracta(new FabricaPociones(Instantiate(Config)));
        if (TipoDePocion == "") {
            Debug.Log("vacio");
        }
    }

    public void Interactuar() {
        // TODO: Falta verificar que el tipo indicado sea válido
        PocionBase pocionCreada = fabrica.CrearPocion(TipoDePocion == "" ? "Vida" : TipoDePocion);
        pocionCreada.transform.position = transform.position + new Vector3(0, 1.25f, 0);
        pocionCreada.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2f), ForceMode2D.Impulse);
        Desactivar();
    }

    public void Activar() {
        Activo = true;
    }

    public void Desactivar(){
        Activo = false;
        Indicador.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D colision) {
        if (colision.gameObject == Jugador) {
            EnRango = true;
            Indicador.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colision) {
        if (colision.gameObject == Jugador) {
            EnRango = false;
            Indicador.GetComponent<SpriteRenderer>().enabled = false;
        }
    }



    private void Awake () {
        Jugador = GameObject.FindGameObjectWithTag("Jugador");
        Indicador = transform.Find("Indicador").gameObject;
        EnRango = false;
        Indicador.GetComponent<SpriteRenderer>().enabled = false;
        Activar();
    }



    private void Update() {
        if( Input.GetKeyDown(KeyCode.Q) && EnRango && Activo) {
            Interactuar();
        }
    }
}