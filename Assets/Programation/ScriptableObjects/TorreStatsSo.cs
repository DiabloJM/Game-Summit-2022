using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Torreta", menuName = "ScrObj/Torreta")]
public class TorreStatsSo : ScriptableObject 
{
    public int damage;
    public float rango;
    public float cadencias;
}

