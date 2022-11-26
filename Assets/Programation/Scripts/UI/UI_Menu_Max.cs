using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu_Max : MonoBehaviour
{


    public float speed;

    //Boton para cerrar la aplicacion 
    public void btn_Salir()
    {
        Application.Quit();
    

    }

    public void btn_Creditos(GameObject canva)
    {
        canva.SetActive(false);
        
    }

    public void activaCanva2(GameObject canva)
    {
        canva.SetActive(true);

    }

    
}
