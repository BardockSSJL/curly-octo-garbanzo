using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public bool PocionVidaDisponible;
    public bool PocionArmaduraDisponible;
    public bool PocionDannoDisponible;
    // Start is called before the first frame update
    void Start()
    {
        PocionArmaduraDisponible = false;
        PocionDannoDisponible = false;
        PocionVidaDisponible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
