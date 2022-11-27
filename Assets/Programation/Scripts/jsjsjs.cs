using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class jsjsjs : MonoBehaviour
{
    public void cambiarNivel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
