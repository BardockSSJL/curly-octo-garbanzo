using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAtaqueEnemigo : MonoBehaviour
{
    [SerializeField] public float radioHitbox;
    [SerializeField] public float dañoAtaque;
    [SerializeField] protected Animator MyAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(GetComponent<CircleCollider2D>());
        Debug.Log(GetComponent<CircleCollider2D>().enabled);
        GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log(GetComponent<CircleCollider2D>().enabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Golpear() {
        MyAnimator.SetTrigger("Atacar");
    }

    private void OnTriggerEnter2D(Collider2D colision) {
        if (colision.gameObject.CompareTag("Jugador")) {
            Debug.Log("Golpeado");
        }
    }

}
