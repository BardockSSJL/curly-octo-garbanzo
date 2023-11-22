using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private Jugador jugador;
    [SerializeField] private Image BarraVidaMax;
    [SerializeField] private Image BarraVidaActual;

    // Start is called before the first frame update
    void Start()
    {
        BarraVidaMax.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        BarraVidaActual.fillAmount = jugador.vidaActual / jugador.vidaMaxima;
    }
}
