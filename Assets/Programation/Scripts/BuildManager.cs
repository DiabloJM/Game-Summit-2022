using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Sirve para referenciar este c�digo en otros c�digos
    public static BuildManager instance;
    //Para cambiar entre torretas conforme las colocas
    public int contadorDeTorretas = 0;

    private void Awake()
    {
        //En el caso de dar click, checar� si est� disponible, si lo est�, instanciar� este script para realizar sus funciones
        if(instance != null)
        {
            Debug.LogError("Ya hay una torreta :C");
            return;
        }
        instance = this;
    }

    public GameObject torretaStandardPrefab; //Torreta de prueba
    public GameObject torreta1, torreta2, torreta3; //Las torretas en forma de prefabs a colocar

    //c�digo de prueba
    /*private void Start()
    {
        //torretaAContstruir = torretaStandardPrefab; 
    }*/

    public void SubirContador()
    {
        contadorDeTorretas += 1;
    }

    public int ObtenerContador()
    {
        return contadorDeTorretas;
    }
    public GameObject ObtenerTorretaAConstruir()
    {
        switch (contadorDeTorretas)
        {
            case 0: return torreta1; 
            case 1: return torreta2; 
            case 2: return torreta3; 
            default: return torretaStandardPrefab;
        }
    }
}
