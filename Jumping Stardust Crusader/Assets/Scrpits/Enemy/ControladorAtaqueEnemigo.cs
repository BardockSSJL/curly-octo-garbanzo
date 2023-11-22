using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAtaqueEnemigo : MonoBehaviour
{
    [SerializeField] public float radioHitbox;
    [SerializeField] public float dañoAtaque;
    [SerializeField] protected Animator MyAnimator;
    private Jugador jugador;

    // Start is called before the first frame update
    void Awake()
    {
        // Parece no funcionar correctamente. Desactivar desde el inspector
        GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Golpear() {
        //MyAnimator.SetTrigger("Atacar");
    }

    private void OnTriggerEnter2D(Collider2D colision) {
        if (colision.gameObject.CompareTag("Jugador")) {
            // TODO: Cambiar por jugador.recibirdaño
            Jugador j = colision.gameObject.GetComponent<Jugador>();
            j.RecibirDanno(dañoAtaque);
            Debug.Log("Golpeado");
        }
    }

}
