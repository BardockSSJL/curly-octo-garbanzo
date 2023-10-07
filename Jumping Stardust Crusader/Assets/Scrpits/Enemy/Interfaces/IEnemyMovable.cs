using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovable
{
    Rigidbody2D RB { get; set; }

    bool viendoDerecha { get; set; }

    void moverEnemigo (Vector2 velocidad);

    void revisarDireccion(Vector2 velocidad);
}
