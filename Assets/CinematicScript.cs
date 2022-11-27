using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class CinematicScript : MonoBehaviour
{
    [SerializeField] VideoPlayer _vp;

    private void Start()
    {
        _vp.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("Ui_MenuPrincipalTest");
    }
}
