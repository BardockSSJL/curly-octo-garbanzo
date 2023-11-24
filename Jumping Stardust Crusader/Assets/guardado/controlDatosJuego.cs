using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class controlDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDatos;
    public DatosJuego datosJuego = new DatosJuego();

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C)){
            cargarDatos();
        }
        if(Input.GetKeyDown(KeyCode.G)){
            guardarDatos();
        }
    }

    private void Awake() {
        archivoDatos = Application.dataPath + "/datosJuego.json";
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    private void cargarDatos()
    {
        if(File.Exists(archivoDatos)){
            string contenido = File.ReadAllText(archivoDatos);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            Debug.Log("cargado con exito");
            jugador.transform.position = datosJuego.posicion;
        } else {
        }
    }

    private void guardarDatos(){
        DatosJuego nuevosDatos = new DatosJuego(){
            posicion = jugador.transform.position
        };
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoDatos, cadenaJSON);
        Debug.Log("guardado con exito");

    }
}
