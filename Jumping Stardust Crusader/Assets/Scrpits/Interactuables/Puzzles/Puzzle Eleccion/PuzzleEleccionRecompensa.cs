using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEleccionRecompensa : PuzzleEleccion
{
    // TODO: Agregar recompensas correctas
    [field : SerializeField] public GameObject recompensa { get; set; }

    public override void Acertar() {
        base.Acertar();
        GameObject recompensaCreada = Instantiate(recompensa, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //recompensaCreada.GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 4), ForceMode2D.Impulse);
        recompensaCreada.GetComponent<Rigidbody2D>().velocity = new Vector2(1,2);
    }

    public override void Fallar() {
        base.Acertar();
    }
}
