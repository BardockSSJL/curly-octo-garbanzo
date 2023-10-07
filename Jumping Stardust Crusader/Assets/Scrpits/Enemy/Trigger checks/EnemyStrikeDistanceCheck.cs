using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikeDistanceCheck : MonoBehaviour
{
    public GameObject JugadorObjetivo { get; set; }
    private Enemy _enemy;

    private void Awake() {
        JugadorObjetivo = GameObject.FindGameObjectWithTag("Jugador");
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D colision) {
        if (colision.gameObject == JugadorObjetivo) {
            _enemy.SetEnRango(true);
        }
    }

    private void OnTriggerExit2D(Collider2D colision) {
        if (colision.gameObject == JugadorObjetivo) {
            _enemy.SetEnRango(false);
        }
    }
}
