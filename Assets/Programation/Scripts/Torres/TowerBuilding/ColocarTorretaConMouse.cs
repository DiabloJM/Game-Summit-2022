using UnityEngine;

public class ColocarTorretaConMouse : MonoBehaviour
{
    [SerializeField]
    Color hoverColor; //Color cuando el cursor est� encima
    [SerializeField]
    Renderer rend;
    [SerializeField]
    Color startColor;

    public bool est�Ocupado;
    GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (!BuildManager.instance.estoyConstruyendo) //Si no estoy construyendo, entonces no hago nada :D
            return;
        if (turret != null) //Si hay torreta en el espacio deseado, no vale verga y no hago nada
            return;

        /*En resumnen
        -obtiene la torreta a construir
        -despu�s la instancia en el lugar deseado
        -cambia el cursor a su estado normal.
        -Como ya construy�, el booleando estoyConstruyendo vuelve a ser falso 
        -baja el score seg�n lo que cost� construir la torre
        -y devuelve el precio actual a 0 por si acaso
        */
        GameObject turretToBuild = BuildManager.instance.ObtenerTorretaAConstruir();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        BuildManager.instance.estoyConstruyendo = false;
        ScoreManager.scoreValue -= BuildManager.precioActual;
        BuildManager.precioActual = 0;
        est�Ocupado = true;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
