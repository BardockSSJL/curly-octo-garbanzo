using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispensador : MonoBehaviour, IInteractuable {

    public bool Activo { get; set; }
    public bool EnRango { get; set; }
    public GameObject Jugador { get; set; }
    public GameObject Indicador { get; set; }

    public void Interactuar() {
        Debug.Log("Tome una poción, joven");
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