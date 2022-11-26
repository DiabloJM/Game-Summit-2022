using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu_Max : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Boton para cerrar la aplicacion 
    public void btn_Salir()
    {
        Application.Quit();
    

    }

    public void btn_Creditos(GameObject canva)
    {
        canva.SetActive(false);
    }


}
