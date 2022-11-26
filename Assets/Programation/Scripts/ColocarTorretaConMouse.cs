using UnityEngine;

public class ColocarTorretaConMouse : MonoBehaviour
{
    [SerializeField]
    Color hoverColor;
    [SerializeField]
    Renderer rend;
    [SerializeField]
    Color startColor;

    GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("No puedo construir aqui Pa");
            return;
        }
        if(BuildManager.instance.ObtenerContador() < 3)
        {
            GameObject turretToBuild = BuildManager.instance.ObtenerTorretaAConstruir();
            BuildManager.instance.SubirContador();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0, 1, 0), transform.rotation);
        }
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
