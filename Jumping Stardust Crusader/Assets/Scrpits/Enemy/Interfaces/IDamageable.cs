using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void dannar(float cantidadDanno);

    void morir();

    float vidaMaxima{get; set;}

    float vidaActual{get; set;}

}
