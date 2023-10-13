using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorSueloEnemigo : MonoBehaviour
{
    [SerializeField] public float distanciaAlSuelo;


    void Update() {
        
    }

    public RaycastHit2D checkForSuelo() {
        return Physics2D.Raycast(transform.position, Vector2.down, distanciaAlSuelo, 1 << LayerMask.NameToLayer("Piso"));
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanciaAlSuelo);
    }
}
