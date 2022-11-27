using UnityEditor;
using UnityEngine;

public class ComportamientoBase : MonoBehaviour
{
    static GameObject[] tilesParaColocarBase;
    static GameObject thisGameobject;

    void Start()
    {
        tilesParaColocarBase = GameObject.FindGameObjectsWithTag("Adyacente");
        thisGameobject = gameObject;
    }

    public static void MoverPosicion()
    {
        int random = Random.Range(0, tilesParaColocarBase.Length);
        ColocarTorretaConMouse tile = tilesParaColocarBase[random].GetComponent<ColocarTorretaConMouse>();
        if (!tile.estaOcupado)
            thisGameobject.transform.position = tilesParaColocarBase[random].transform.position;
        else
            MoverPosicion();
    }
}
