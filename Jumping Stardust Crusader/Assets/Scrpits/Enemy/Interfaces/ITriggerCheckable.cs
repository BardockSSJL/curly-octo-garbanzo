using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool EstadoAggro {get; set; }
    bool EnRango { get; set; }

    void SetEstadoAggro (bool TieneAggro);
    void SetEnRango (bool EstaEnRango);

}
