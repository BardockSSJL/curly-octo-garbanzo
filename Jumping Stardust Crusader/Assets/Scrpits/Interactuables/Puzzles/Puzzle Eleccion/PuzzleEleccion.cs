using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PuzzleEleccion : MonoBehaviour, IPuzzle
{
    [field : SerializeField] OpcionPuzzleEleccion opcion1 { get; set; }
    [field : SerializeField] OpcionPuzzleEleccion opcion2 { get; set; }
    [field : SerializeField] OpcionPuzzleEleccion opcion3 { get; set; }
    
    void Awake()
    {
        opcion1.transform.localPosition = new Vector3((float)-1.25, 0, 0);
        opcion2.transform.localPosition = new Vector3((float)0, 0, 0);
        opcion3.transform.localPosition = new Vector3((float)1.25, 0, 0);
        opcion1.opcionCorrecta = false;
        opcion2.opcionCorrecta = false;
        opcion3.opcionCorrecta = false;
        int opcionCorrecta = ((int)DateTime.Now.Millisecond) % 3;
        switch (opcionCorrecta)
        {
            case 0:
            opcion1.opcionCorrecta = true;
            break;
            case 1:
            opcion2.opcionCorrecta = true;
            break;
            case 2:
            opcion2.opcionCorrecta = true;
            break;
        }
    }

    public virtual void Fallar(){
        Debug.Log("Nope!");
        Desactivar();
    }
    public virtual void Acertar(){
        Debug.Log("Tome una poción, joven");
        Desactivar();
    }

    private void Desactivar() {
        opcion1.Desactivar();
        opcion2.Desactivar();
        opcion3.Desactivar();
    }
    
}
