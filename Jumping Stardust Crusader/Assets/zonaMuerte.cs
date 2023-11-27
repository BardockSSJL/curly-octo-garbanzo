using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zonaMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.gameObject.tag == "Jugador"){
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


