using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAtaqueEnemigo : MonoBehaviour
{
    [SerializeField] public float radioHitbox;
    [SerializeField] public float dañoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Golpear() {
        Collider2D[] objetosGolpeados = Physics2D.OverlapCircleAll(transform.position, radioHitbox);
        foreach (Collider2D objetoGolpeado in objetosGolpeados) {
            if (objetoGolpeado.CompareTag("Jugador") == true)
            {
                Debug.Log("golpeado");
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioHitbox);
    }
}
