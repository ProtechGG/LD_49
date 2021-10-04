using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HEH;
    public PlyerControlller c;
    public void start()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void ez()
    {
        c.ez = true;
        HEH.SetActive(false);
    }
    public void hard()
    {
        c.ez = false;
        HEH.SetActive(false);
    }
}
