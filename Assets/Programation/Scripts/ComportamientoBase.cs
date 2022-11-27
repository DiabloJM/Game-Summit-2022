using UnityEngine;

public class ComportamientoBase : MonoBehaviour
{
    GameObject[] tilesParaColocarBase;
    int contadorDeOleadasProvisional = 0;

    // Start is called before the first frame update
    void Start()
    {
        tilesParaColocarBase = GameObject.FindGameObjectsWithTag("Adyacente");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            contadorDeOleadasProvisional++;
            MoverPosicion();
        }
    }

    void MoverPosicion()
    {
        int random = Random.Range(0, tilesParaColocarBase.Length);
        ColocarTorretaConMouse tile = tilesParaColocarBase[random].GetComponent<ColocarTorretaConMouse>();
        if (!tile.est·Ocupado)
            transform.position = tilesParaColocarBase[random].transform.position;
        else
            MoverPosicion();
    }
}
