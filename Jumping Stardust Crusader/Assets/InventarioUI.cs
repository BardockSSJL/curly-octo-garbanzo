using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioUI : MonoBehaviour
{
    [SerializeField] InventarioJugador inventarioJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().enabled = inventarioJugador.PocionVidaDisponible;
        gameObject.transform.GetChild(1).GetComponent<Image>().enabled = inventarioJugador.PocionDannoDisponible;
        gameObject.transform.GetChild(2).GetComponent<Image>().enabled = inventarioJugador.PocionArmaduraDisponible;
    }
}
