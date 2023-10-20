using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractuable
{
    bool Activo { get; set; }
    bool EnRango { get; set; }
    GameObject Jugador { get; set; }
    GameObject Indicador { get; set; }
    void Interactuar();
    void Activar();
    void Desactivar();
}